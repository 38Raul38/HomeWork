const API_KEY = '916fb2e9d16542f0915d0814175631ab';
let currentCategory = 'general';
let currentPage = 1;

document.querySelectorAll('.nav-link').forEach(link => {
  link.addEventListener('click', (e) => {
    e.preventDefault();

    document.querySelectorAll('.nav-link').forEach(el => el.classList.remove('active'));
    e.target.classList.add('active');

    currentCategory = e.target.dataset.category;
    currentPage = 1;
    loadNews(currentCategory, true); // Сброс новостей
  });
});

function capitalize(word) {
  return word.charAt(0).toUpperCase() + word.slice(1);
}

const loadMoreBtn = document.getElementById('load-more-btn');
loadMoreBtn.addEventListener('click', () => {
  currentPage++;
  loadNews(currentCategory);
});

loadNews(currentCategory);

async function loadNews(category = 'general', reset = false) {
  const endpoint = `https://newsapi.org/v2/top-headlines?country=us&category=${category}&pageSize=10&page=${currentPage}&apiKey=${API_KEY}`;
  const container = document.getElementById('news-container');
  const title = document.getElementById('category-title');
  const loader = document.getElementById('loader');

  title.textContent = `${capitalize(category)} News`;
  loader.classList.remove('hidden');
  container.classList.add('hidden');
  loadMoreBtn.classList.add('hidden');

  try {
    const response = await fetch(endpoint);
    const data = await response.json();

    if (data.status !== 'ok') throw new Error('API вернул ошибку');

    if (reset) container.innerHTML = '';

    if (data.articles.length === 0 && currentPage === 1) {
      container.innerHTML = '<p>No articles found in this category.</p>';
    } else {
      data.articles.forEach(article => {
        const card = document.createElement('div');
        card.className = 'article';
        card.innerHTML = `
          ${article.urlToImage ? `<img src="${article.urlToImage}" alt="News Image">` : ''}
          <h3>${article.title}</h3>
          <p>${article.description || 'No description available.'}</p>
          <a href="${article.url}" target="_blank">Read more</a>
          <p class="date">Published: ${new Date(article.publishedAt).toLocaleString()}</p>
        `;
        container.appendChild(card);
      });

      if (data.articles.length === 10) {
        loadMoreBtn.classList.remove('hidden');
      }
    }
  } catch (error) {
    console.error('Ошибка:', error);
    container.innerHTML = '<p>Error loading news. Please try again later.</p>';
  }

  loader.classList.add('hidden');
  container.classList.remove('hidden');
}

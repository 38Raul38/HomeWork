 const API_KEY = "a5ddefa4165f6dd4b161197714b04cd0"; 
    let cities = [];
    let currentPage = 1;
    const perPage = 5;

window.addEventListener("DOMContentLoaded", () => {
  const params = new URLSearchParams(window.location.search);
  const lat = parseFloat(params.get("lat"));
  const lon = parseFloat(params.get("lng"));

  if (!lat || !lon) {
    document.getElementById("weather-container").innerHTML = "Координаты не переданы.";
    return;
  }

  onAddressSelected(lat, lon);
});


    window.addEventListener("DOMContentLoaded", () => {
  const params = new URLSearchParams(window.location.search);
  const lat = parseFloat(params.get("lat"));
  const lon = parseFloat(params.get("lng"));

  if (!lat || !lon) {
    document.getElementById("weather-container").innerHTML = "Координаты не переданы.";
    return;
  }

  onAddressSelected(lat, lon);
});


    async function getNearbyCitiesWeather(lat, lon) {
      const url = `https://api.openweathermap.org/data/2.5/find?lat=${lat}&lon=${lon}&cnt=50&units=metric&appid=${API_KEY}`;
      try {
        const res = await fetch(url);
        const data = await res.json();
        if (data.cod !== "200") {
          alert("Ошибка при получении данных");
          return [];
        }
        return data.list;
      } catch (err) {
        console.error(err);
        alert("Ошибка подключения к API");
        return [];
      }
    }

async function onAddressSelected(lat, lon) {
  const loadingText = document.getElementById("weather-container");
  loadingText.innerHTML = "<p>Загружаем погоду...</p>";

  cities = await getNearbyCitiesWeather(lat, lon);
  if (cities.length === 0) {
    loadingText.innerHTML = "<p>Нет данных о погоде для этого места.</p>";
    return;
  }

  currentPage = 1;
  displayPage(currentPage);
}


    function displayPage(page) {
      const start = (page - 1) * perPage;
      const end = start + perPage;
      const visibleCities = cities.slice(start, end);

      const container = document.getElementById("weather-container");
      container.innerHTML = "";

      visibleCities.forEach(city => {
        const div = document.createElement("div");
        div.className = "city-weather";
        div.innerHTML = `
          <h3>${city.name}</h3>
          <p><strong>Температура:</strong> ${city.main.temp}°C</p>
          <p><strong>Ощущается как:</strong> ${city.main.feels_like}°C</p>
          <p><strong>Влажность:</strong> ${city.main.humidity}%</p>
          <p><strong>Погода:</strong> ${city.weather[0].description}</p>
          <p><strong>Ветер:</strong> ${city.wind.speed} м/с</p>
        `;
        container.appendChild(div);
      });

      updatePaginationControls();
    }

    function updatePaginationControls() {
      const totalPages = Math.ceil(cities.length / perPage);
      const controls = document.getElementById("pagination");
      controls.innerHTML = "";

      for (let i = 1; i <= totalPages; i++) {
        const btn = document.createElement("button");
        btn.textContent = i;
        btn.className = i === currentPage ? "active" : "";
        btn.onclick = () => {
          currentPage = i;
          displayPage(currentPage);
        };
        controls.appendChild(btn);
      }
    }
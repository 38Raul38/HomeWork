const list = document.querySelector('#textList');

list.addEventListener('click', function(event) {
  if (event.target.tagName === 'LI') {
    Array.from(list.children).forEach(li => {
      li.style.backgroundColor = '';
      li.style.color = '';
    });

    event.target.style.backgroundColor = 'orange';
    event.target.style.color = 'white';
  }
});

const lights = document.querySelectorAll('.circle');
const btn = document.querySelector('.button')

const activeColors = ['red', 'yellow', 'limegreen'];
const unactiveColor = 'rgb(229,177,114)';

let current = 0;

lights.forEach(light => {
    light.style.backgroundColor = unactiveColor;
})
lights[current].style.backgroundColor = activeColors[current]

btn.addEventListener('click', ()=>{
    lights[current].style.backgroundColor = unactiveColor;
    current = (current + 1) % lights.length;
    lights[current].style.backgroundColor = activeColors[current];
});
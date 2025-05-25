const openBtn = document.getElementById('openBtn')
const closeBtn = document.getElementById('closeBtn')
const overlay = document.getElementById('overlay')

openBtn.addEventListener('click', () => {
    overlay.style.display = 'flex'
})

closeBtn.addEventListener('click', () => {
    overlay.style.display = 'none'
})
    document.body.onclick = function (event) {
      let ball = document.querySelector('ball');
      ball.style.top  = event.clientY + 'px';
      ball.style.left = event.clientX + 'px';
    };
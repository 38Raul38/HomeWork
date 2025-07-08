const container = document.getElementById('container');
        const toggleBtn = document.getElementById('toggleBtn');
        const welcomeTitle = document.getElementById('welcomeTitle');
        const welcomeText = document.getElementById('welcomeText');
        const signupForm = document.getElementById('signupForm');
        const signinForm = document.getElementById('signinForm');

        let isSignUp = true;

        toggleBtn.addEventListener('click', () => {
            if (isSignUp) {
                container.classList.add('sign-in-mode');
                welcomeTitle.textContent = 'Hello, Friend!';
                welcomeText.textContent = 'Enter your personal details and start journey with us';
                toggleBtn.textContent = 'SIGN UP';
                
                signupForm.classList.remove('active');
                signinForm.classList.add('active');
                
                isSignUp = false;
            } else {
                container.classList.remove('sign-in-mode');
                welcomeTitle.textContent = 'Welcome Back!';
                welcomeText.textContent = 'To keep connected with us please login with your personal info';
                toggleBtn.textContent = 'SIGN IN';
                
                signinForm.classList.remove('active');
                signupForm.classList.add('active');
                
                isSignUp = true;
            }
        });

        document.querySelectorAll('form').forEach(form => {
            form.addEventListener('submit', (e) => {
                e.preventDefault();
                
                const formType = form.closest('.form').id === 'signupForm' ? 'регистрации' : 'входа';
                alert(`Форма ${formType} отправлена! (это демо-версия)`);
            });
        });

        
const registerForm = document.getElementById('registerForm');
const loginForm = document.getElementById('loginForm');

// Регистрация
registerForm.addEventListener('submit', async (e) => {
    e.preventDefault();

try{
    const name = registerForm.querySelector('input[placeholder="Name"]').value;
    const email = registerForm.querySelector('input[placeholder="Email"]').value;
    const password = registerForm.querySelector('input[placeholder="Password"]').value;

    const res = await fetch('/api/register', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ name, email, password })
    });

    const data = await res.json();
    alert(data.message);

    if(res.ok){
        window.location.href = "mapslocation/locindex.html"
    }
}

catch(err){
    console.error("Error registration", error);
    alert(err.message);
}
});

// Логин
loginForm.addEventListener('submit', async (e) => {
    e.preventDefault();

    const email = loginForm.querySelector('input[placeholder="Email"]').value;
    const password = loginForm.querySelector('input[placeholder="Password"]').value;

try{    
    const res = await fetch('/api/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password })
    });

    if(res.ok){
        window.location.href = "mapslocation/locindex.html"
    }

    const data = await res.json();
    alert(data.message);
}

catch(err){
    console.error("Error Login", err)
    alert(err.message);
}
});

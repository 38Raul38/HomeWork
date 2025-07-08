const fs = require('fs').promises;
const express = require('express');
const bcrypt = require('bcrypt');

const app = express();
const DB = 'users.json';
const port = 3000;

app.use(express.static('private'));
app.use('/mapslocation', express.static('private/mapslocation'));
app.use('/weather', express.static('weather'));

app.use(express.json());


//Registration
app.post('/api/register', async (req, res) => {
    const {name, email, password} = req.body;
    
    if (!name || !email || !password) {
        return res.status(400).json({
            success: false,
            message: 'All fields are required to fill in'
        });
    }
    
    const emailReqex =  /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if(!emailReqex.test(email)){
        return res.status(400).json({
            success: false,
            message: 'Please provide a valid email address'
        });
    }
    
    if (password.length < 6) {
        return res.status(400).json({
            success: false,
            message: 'Password must be at least 6 characters long'
        });
    }    
    
    const users = JSON.parse(await fs.readFile(DB));


    const ExistingUser = users.find(user => user.email === email);
    if (ExistingUser) {
        return res.status(409).json({
            success: false,
            message: 'The user with this email already exists'
        });
    }

    const numSaltRounds = 8;
    const hashPassword = await bcrypt.hash(password, numSaltRounds);

    const newUser = {
        id: Date.now(),
        name,
        email: email.toLowerCase(),
        password: hashPassword,
        createdAt: new Date().toISOString()
    };

    users.push(newUser);
    await fs.writeFile(DB, JSON.stringify(users, null, 2));

    res.status(201).json({
        success: true,
        message: 'User registered succesfully'
    });
});


//Login
app.post('/api/login', async(req, res ) => {
    const {email, password} = req.body;

    if(!email || !password){
        return res.status(400).json({
            success: false,
            message: 'All fields are required to fill in'
        });
    }

    const users = JSON.parse(await fs.readFile(DB));
    const user = users.find(u => u.email.toLowerCase() === email.toLowerCase());

    if(!user){
        return res.status(401).json({
            success: false,
            message: 'Invalid email or password'
        });
    }

    const IsPassword = await bcrypt.compare(password, user.password);
    if(!IsPassword){
        return res.status(401).json({
            success: false,
            message: 'Invalid email or password'
        });
    } else{
        return res.status(200).json({
            success: true,
            message: 'Login successful',
            user: {
                id: user.id,
                name: user.name,
                email: user.email
            }
        });
    }
})

app.listen(port, () => {
    console.log(`Server running on http://localhost:${port}`)
})

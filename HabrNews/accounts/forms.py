from django import forms
from django.contrib.auth.models import User

class RegisterForm(forms.ModelForm):
    username = forms.CharField(
        label='Username',
        max_length=150,
        min_length=4,
        widget=forms.TextInput(
            attrs={
                'class': 'form-control',
                'placeholder': 'Enter your username',
            }
        ),
    )

    email = forms.EmailField(
        label='Email',
        widget=forms.EmailInput(
            attrs={
                'class': 'form-control',
                'placeholder': 'Enter your email',
                'autocomplete': 'email',
            }
        ),
    )

    password = forms.CharField(
        label='Password',
        min_length=5,
        widget= forms.PasswordInput(
            attrs={
                'class': 'form-control',
                'placeholder': 'Enter your password',
                'autocomplete': 'new-password',
            }
        ),
    )

    confirm_password = forms.CharField(
        label= 'Confirm Password',
        min_length=5,
        widget=forms.PasswordInput(
            attrs={
                'class': 'form-control',
                'placeholder': 'Confirm your password',
                'autocomplete': 'new-password',
            }
        ),
    )

    def clean(self):
        self.cleaned_data = super().clean()
        password = self.cleaned_data.get('password')
        confirm_password = self.cleaned_data.get('confirm_password')
        if password and confirm_password and password != confirm_password:
            raise forms.ValidationError('Passwords do not match')
        return self.cleaned_data
    
class LoginForm(forms.Form):
    username_or_email = forms.CharField(
        label='Username or Email',
        widget= forms.TextInput(
            attrs={
                'class': 'form-control',
                'placeholder': 'Enter your username or email',
                'autocomplete': 'username',
            }
        ),
    )
    password = forms.CharField(
        label='Password',
        widget=forms.PasswordInput(
            attrs={
                'class': 'form-control',
                'placeholder': 'Enter your password',
                'autocomplete': 'current-password',
            }
        ),
    )
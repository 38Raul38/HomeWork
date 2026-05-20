from django.urls import path
from django.contrib.auth import views as auth_views

from accounts.forms import LoginForm
from . import views

app_name = 'accounts'

urlpatterns = [
    path('register/', views.register_view, name='register'),
    path('login/', auth_views.LoginView.as_view(template_name='accounts/login.html', authentication_form=LoginForm), name='login'),
    path('logout/', auth_views.LogoutView.as_view(), name='logout'),
    
    path('admin_dashboard/', views.admin_dashboard_view, name='admin_dashboard'),
    path('ban/<int:user_id>/', views.ban_user_view, name='ban_user'),
    path('unban/<int:user_id>/', views.unban_user_view, name='unban_user'),
    path('change_role/<int:user_id>/<str:new_role>/', views.change_role_view, name='change_role'),
]

from django.shortcuts import get_object_or_404, redirect, render
from django.contrib.auth.decorators import user_passes_test

from accounts.forms import RegisterForm
from accounts.models import CustomUser
from article.models import Article

def register_view(request):
    if request.method == 'POST':
        form = RegisterForm(request.POST)
        if form.is_valid():
            form.save()
            return redirect('accounts:login')
    else:
        form = RegisterForm()
    return render(request, 'accounts/register.html', {'form': form})

def is_admin(user):
    return user.is_authenticated and user.role in ['admin', 'superadmin']

def is_superadmin(user):
    return user.is_authenticated and user.role == 'superadmin'

@user_passes_test(is_admin)
def admin_dashboard_view(request):
    users = CustomUser.objects.all()
    pending_articles = Article.objects.filter(status='pending').order_by('-published_date')
    return render(request, 'accounts/admin_dashboard.html', {
        'users': users,
        'pending_articles': pending_articles
    })

@user_passes_test(is_admin)
def ban_user_view(request, user_id):
    user = get_object_or_404(CustomUser, id=user_id)
    user.is_active = False
    user.save()
    return redirect('accounts:admin_dashboard') 

@user_passes_test(is_admin)
def unban_user_view(request, user_id):
    user = get_object_or_404(CustomUser, id=user_id)
    user.is_active = True
    user.save()
    return redirect('accounts:admin_dashboard')

@user_passes_test(is_superadmin)
def change_role_view(request, user_id, new_role):
    user = get_object_or_404(CustomUser, id=user_id)
    if new_role in [role[0] for role in CustomUser.ROLE_CHOICES]:
        user.role = new_role
        user.save()
    return redirect('accounts:admin_dashboard')
from django.urls import path

from . import views

app_name = 'article'

urlpatterns = [
    path('create/', views.article_create, name='article_create'),
    path('update/<slug:slug>/', views.article_update, name='article_update'),
    path('delete/<slug:slug>/', views.article_delete, name='article_delete'),
]

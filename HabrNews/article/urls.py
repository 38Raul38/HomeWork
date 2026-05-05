from django.urls import path

from . import views

app_name = 'article'

urlpatterns = [
    path('', views.article_list, name='article_list'),
    path('popular/', views.popular_articles, name='popular_articles'),
    path('category/<str:category>/', views.category_articles, name='category_articles'),
    path('authors/', views.author_list, name='author_list'),
    path('bookmarks/', views.bookmark_list, name='bookmark_list'),

    path('create/', views.article_create, name='article_create'),
    path('<slug:slug>/', views.article_detail, name='article_detail'),
    path('update/<slug:slug>/', views.article_update, name='article_update'),
    path('delete/<slug:slug>/', views.article_delete, name='article_delete'),
    
    path('toggle_bookmark/<slug:slug>/', views.toggle_bookmark, name='toggle_bookmark'),
    path('rate/<slug:slug>/', views.rate_article, name='rate_article'),
    
    path('approve/<slug:slug>/', views.article_approve, name='article_approve'),
    path('reject/<slug:slug>/', views.article_reject, name='article_reject'),
]

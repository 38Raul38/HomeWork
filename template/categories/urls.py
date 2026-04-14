from django.urls import path

from . import views
from .views import AboutPageView

app_name = 'categories'

urlpatterns = [
    path('', views.main, name='main'),
    path('football/', views.football, name='football'),
    path('hockey/', views.hockey, name='hockey'),
    path('basketball/', views.basketball, name='basketball'),
]
from django.urls import path

# from categories.views import Home, Football, Basketball, Hockey
from categories import views

app_name = "categories"

urlpatterns = [
    path('', views.Home, name='home'),
    path('football/', views.Football, name='football'),
    path('basketball/', views.Basketball, name='basketball'),
    path('hockey/', views.Hockey, name='hockey'),
]
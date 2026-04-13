from django.urls import path
from . import views

urlpatterns = [
    path('weekday', views.todays_weekday, name="todays_weekday"),
]
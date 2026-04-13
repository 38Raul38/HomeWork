from django.urls import path
from . import views

urlspatterns = [
    path('quotes', views.random_quotes, name="random_quotes"),
]
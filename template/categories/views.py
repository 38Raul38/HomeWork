from django.http import HttpRequest, HttpResponse
from django.shortcuts import render


def Home(request: HttpRequest) -> HttpResponse:
    return render(request, "categories/home.html")

def Football(request: HttpRequest) -> HttpResponse:
    return render(request, "categories/football.html")

def Basketball(request: HttpRequest) -> HttpResponse:
    return render(request, "categories/basketball.html")

def Hockey(request: HttpRequest) -> HttpResponse:
    return render(request, "categories/hockey.html")
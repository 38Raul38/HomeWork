from django.shortcuts import render
from django.http import HttpResponse, HttpRequest

def hello(request: HttpRequest) -> HttpResponse:
    return HttpResponse("Hello, World!")
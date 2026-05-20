from django.shortcuts import render
from django.http import HttpResponse, HttpRequest
import datetime

def todays_weekday(request: HttpRequest) -> HttpResponse:
    today = datetime.datetime.now().strftime("%A")
    return HttpResponse(today)
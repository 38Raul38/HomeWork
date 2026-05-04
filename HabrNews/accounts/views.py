from django.shortcuts import render

def register_view(request):
    if request.method == 'POST':
        
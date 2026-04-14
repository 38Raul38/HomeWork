from django.shortcuts import render

def main(request):
    return render(request, 'main.html')

def football(request):
    return render(request, 'football.html')

def hockey(request):
    return render(request, 'hockey.html')

def basketball(request):
    return render(request, 'basketball.html')

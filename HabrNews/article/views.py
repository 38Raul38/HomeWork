from django.shortcuts import render

from article.models import Article

def article_list(request):
    # Здесь можно получить список статей из базы данных и передать их в шаблон
    articles = Article.objects.all()
    return render(request, 'article_list.html', {'articles': articles})
from pyexpat.errors import messages

from django.http import HttpResponse, HttpRequest, HttpResponseForbidden
from django.shortcuts import get_object_or_404, redirect, render
from django.contrib.auth.decorators import login_required

from article.models import Article

def article_list(request: HttpRequest) -> HttpResponse:
    articles = Article.objects.all() #можно добавить пагинацию, фильтрацию по категории и т.д.
    return render(request, 'article/article_list.html', {'articles': articles})

@login_required
def article_detail(request: HttpRequest, slug: str) -> HttpResponse: 
    article = Article.objects.get(slug=slug)
    return render(request, 'article/article_detail.html', {'article': article})


@login_required
def article_create(request: HttpRequest) -> HttpResponse:
    if request.method == 'POST':
        form = ArticleForm(request.POST, request.FILES) # для загрузки изображений нужно добавить request.FILES
        if form.is_valid():
            article = form.save(commit=False)
            article.author = request.user
            article.save()
            form.save_m2m()
            messages.success(request, 'Article created successfully!')
            return redirect('article_detail', slug=article.slug)
    else:
        form = ArticleForm()
    return render(request, 'article/article_form.html', {'form': form})

@login_required
def article_update(request: HttpRequest, slug: str) -> HttpResponse:
    article = get_object_or_404(Article, slug=slug)

    if article.author != request.user:
        return HttpResponseForbidden('You are not allowed to edit this article.')
    
    if request.method == 'POST':
        form = ArticleForm(request.POST, request.FILES, instance=article)
        if form.is_valid():
            form.save()
            messages.success(request, 'Article updated successfully!')
            return redirect('article_detail', slug=article.slug)
    else:
        form = ArticleForm(instance=article)
    return render(request, 'article/article_form.html', {'form': form})

@login_required
def article_delete(request: HttpRequest, slug: str) -> HttpResponse:
    article = get_object_or_404(Article, slug=slug)

    if article.author != request.user:
        return HttpResponseForbidden('You are not allowed to delete this article.')
    
    if request.method == 'POST':
        article.delete()
        messages.success(request, 'Article deleted successfully!')
        return redirect('article_list') # article:article_list'
    return render(request, 'article/article_confirm_delete.html', {'article': article})

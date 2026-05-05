from django.contrib import messages
from django.db.models import Avg, Count, Q

from django.http import HttpResponse, HttpRequest, HttpResponseForbidden
from django.shortcuts import get_object_or_404, redirect, render
from django.contrib.auth.decorators import login_required

from article.models import Article, Rating
from accounts.models import CustomUser
from article.forms import ArticleForm

def article_list(request: HttpRequest) -> HttpResponse:
    if request.user.is_authenticated:
        articles = Article.objects.filter(
            Q(status='approved') | Q(author=request.user)
        ).order_by('-published_date')
    else:
        articles = Article.objects.filter(status='approved').order_by('-published_date')
    return render(request, 'article/article_list.html', {'articles': articles, 'page_title': 'All Articles'})

def popular_articles(request: HttpRequest) -> HttpResponse:
    articles = Article.objects.filter(status='approved').annotate(
        avg_rating=Avg('ratings__value')
    ).filter(avg_rating__gte=4.0).order_by('-avg_rating')
    return render(request, 'article/article_list.html', {'articles': articles, 'page_title': 'Popular Articles'})

def category_articles(request: HttpRequest, category: str) -> HttpResponse:
    if request.user.is_authenticated:
        articles = Article.objects.filter(
            (Q(status='approved') | Q(author=request.user)),
            category=category
        ).order_by('-published_date')
    else:
        articles = Article.objects.filter(status='approved', category=category).order_by('-published_date')
    return render(request, 'article/article_list.html', {'articles': articles, 'page_title': f'Category: {category}'})

def author_list(request: HttpRequest) -> HttpResponse:
    authors = CustomUser.objects.annotate(
        approved_count=Count('articles', filter=Q(articles__status='approved'))
    ).order_by('-approved_count')
    return render(request, 'article/author_list.html', {'authors': authors})

@login_required
def bookmark_list(request: HttpRequest) -> HttpResponse:
    articles = request.user.bookmarked_articles.filter(
        Q(status='approved') | Q(author=request.user)
    ).order_by('-published_date')
    return render(request, 'article/article_list.html', {'articles': articles, 'page_title': 'My Bookmarks'})

@login_required
def toggle_bookmark(request: HttpRequest, slug: str) -> HttpResponse:
    article = get_object_or_404(Article, slug=slug)
    if request.method == 'POST':
        if request.user in article.bookmarks.all():
            article.bookmarks.remove(request.user)
            messages.success(request, 'Removed from bookmarks.')
        else:
            article.bookmarks.add(request.user)
            messages.success(request, 'Added to bookmarks.')
    return redirect('article:article_detail', slug=slug)

@login_required
def rate_article(request: HttpRequest, slug: str) -> HttpResponse:
    article = get_object_or_404(Article, slug=slug)
    if request.method == 'POST':
        val = request.POST.get('value')
        if val and val.isdigit() and 1 <= int(val) <= 5:
            Rating.objects.update_or_create(
                user=request.user, article=article,
                defaults={'value': int(val)}
            )
            messages.success(request, 'Rating saved.')
    referer = request.META.get('HTTP_REFERER')
    if referer:
        return redirect(referer)
    return redirect('article:article_detail', slug=slug)

@login_required
def article_detail(request: HttpRequest, slug: str) -> HttpResponse: 
    article = get_object_or_404(Article, slug=slug)
    
    if article.status != 'approved':
        if article.author != request.user and request.user.role not in ['admin', 'superadmin']:
            return HttpResponseForbidden('You are not allowed to view this article.')
            
    return render(request, 'article/article_detail.html', {'article': article})


@login_required
def article_create(request: HttpRequest) -> HttpResponse:
    if request.method == 'POST':
        form = ArticleForm(request.POST, request.FILES)
        if form.is_valid():
            article = form.save(commit=False)
            article.author = request.user
            if request.user.role in ['admin', 'superadmin']:
                article.status = 'approved'
            else:
                article.status = 'pending'
            article.save()
            # form.save_m2m() # Only needed if ArticleForm includes m2m fields
            messages.success(request, 'Article created successfully!')
            return redirect('article:article_detail', slug=article.slug)
    else:
        form = ArticleForm()
    return render(request, 'article/article_form.html', {'form': form})

@login_required
def article_update(request: HttpRequest, slug: str) -> HttpResponse:
    article = get_object_or_404(Article, slug=slug)

    is_admin = request.user.role in ['admin', 'superadmin']
    if article.author != request.user and not is_admin:
        return HttpResponseForbidden('You are not allowed to edit this article.')
    
    if request.method == 'POST':
        form = ArticleForm(request.POST, request.FILES, instance=article)
        if form.is_valid():
            updated_article = form.save(commit=False)
            if is_admin:
                updated_article.status = 'approved'
            else:
                updated_article.status = 'pending'
            updated_article.save()
            messages.success(request, 'Article updated successfully!')
            return redirect('article:article_detail', slug=updated_article.slug)
    else:
        form = ArticleForm(instance=article)
    return render(request, 'article/article_form.html', {'form': form})

@login_required
def article_delete(request: HttpRequest, slug: str) -> HttpResponse:
    article = get_object_or_404(Article, slug=slug)
    
    is_admin = request.user.role in ['admin', 'superadmin']
    if article.author != request.user and not is_admin:
        return HttpResponseForbidden('You are not allowed to delete this article.')
    
    if request.method == 'POST':
        article.delete()
        messages.success(request, 'Article deleted successfully!')
        return redirect('article:article_list')
    return render(request, 'article/article_confirm_delete.html', {'article': article})

@login_required
def article_approve(request: HttpRequest, slug: str) -> HttpResponse:
    article = get_object_or_404(Article, slug=slug)
    if request.user.role not in ['admin', 'superadmin']:
        return HttpResponseForbidden('Admins only.')
    
    if request.method == 'POST':
        article.status = 'approved'
        article.save()
        messages.success(request, 'Article approved.')
    return redirect('accounts:admin_dashboard')

@login_required
def article_reject(request: HttpRequest, slug: str) -> HttpResponse:
    article = get_object_or_404(Article, slug=slug)
    if request.user.role not in ['admin', 'superadmin']:
        return HttpResponseForbidden('Admins only.')
    
    if request.method == 'POST':
        article.status = 'rejected'
        article.save()
        messages.success(request, 'Article rejected.')
    return redirect('accounts:admin_dashboard')


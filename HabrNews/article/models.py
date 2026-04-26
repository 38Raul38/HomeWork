from django.db import models
from django.conf import settings


class Category(models.Model):
    name = models.CharField(max_length=30, unique=True)
    slug = models.SlugField(max_length=30, unique=True)

    class Meta:
        verbose_name = 'Category'
        verbose_name_plural = 'Categories'
        ordering = ['name']

    def __str__(self):
        return self.name


class Article(models.Model):
    picture = models.ImageField(upload_to='article_pictures/') #(лучше хранить на https://cloudinary.com/)
    content = models.TextField()
    title = models.CharField(max_length=200)
    slug = models.SlugField(max_length=200, unique=True)
    published_date = models.DateTimeField(auto_now_add=True)

    author = models.ForeignKey(
        settings.AUTH_USER_MODEL,
        on_delete=models.CASCADE,
        related_name='articles'
    )

    category = models.ForeignKey(
        Category,
        on_delete=models.PROTECT,
        related_name='articles'
    )

    class Meta:
        verbose_name = 'Article'
        verbose_name_plural = 'Articles'
        ordering = ['-published_date']

    def __str__(self):
        return self.title


class Reaction(models.Model):

    LIKE = 'like'
    DISLIKE = 'dislike'

    REACTION_CHOICES = [
        (LIKE, 'Like'),
        (DISLIKE, 'Dislike'),
    ]

    user = models.ForeignKey(
        settings.AUTH_USER_MODEL,
        on_delete=models.CASCADE,                          
        related_name='reactions'
    )

    article = models.ForeignKey(
        Article,
        on_delete=models.CASCADE,
        related_name='reactions'
    )

    reaction = models.CharField(max_length=7, choices=REACTION_CHOICES)

    class Meta:
        verbose_name = 'Reaction'
        verbose_name_plural = 'Reactions'
        unique_together = ('article', 'user')
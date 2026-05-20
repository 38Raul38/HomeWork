from django.db import models
from django.conf import settings
from django.utils.text import slugify
import uuid


class Article(models.Model):
    CATEGORY_CHOICES = (
        ('Backend', 'Backend'),
        ('Frontend', 'Frontend'),
        ('AI', 'AI'),
        ('Cyber Security', 'Cyber Security'),
        ('Cyber Sport', 'Cyber Sport'),
        ('Game Development', 'Game Development'),
    )
    
    STATUS_CHOICES = (
        ('pending', 'Pending'),
        ('approved', 'Approved'),
        ('rejected', 'Rejected'),
    )

    picture = models.ImageField(upload_to='article_pictures/', null=True, blank=True) #(лучше хранить на https://cloudinary.com/)
    content = models.TextField()
    title = models.CharField(max_length=200)
    slug = models.SlugField(max_length=200, unique=True)
    published_date = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    author = models.ForeignKey(
        settings.AUTH_USER_MODEL,
        on_delete=models.CASCADE,
        related_name='articles'
    )

    category = models.CharField(max_length=30, choices=CATEGORY_CHOICES, default='Backend')
    status = models.CharField(max_length=20, choices=STATUS_CHOICES, default='pending')
    
    bookmarks = models.ManyToManyField(
        settings.AUTH_USER_MODEL,
        related_name='bookmarked_articles',
        blank=True
    )

    class Meta:
        verbose_name = 'Article'
        verbose_name_plural = 'Articles'
        ordering = ['-published_date']

    def __str__(self):
        return self.title

    @property
    def rating_avg(self):
        ratings = self.ratings.all()
        if not ratings:
            return 0.0
        avg = sum(r.value for r in ratings) / len(ratings)
        return round(avg, 1)

    def save(self, *args, **kwargs):
        if not self.slug:
            # Generate slug from title
            base_slug = slugify(self.title)
            if not base_slug:
                base_slug = "article"
            self.slug = f"{base_slug}-{uuid.uuid4().hex[:6]}"
            
            # Ensure uniqueness
            while Article.objects.filter(slug=self.slug).exists():
                self.slug = f"{base_slug}-{uuid.uuid4().hex[:6]}"
        super().save(*args, **kwargs)


class Rating(models.Model):
    user = models.ForeignKey(
        settings.AUTH_USER_MODEL,
        on_delete=models.CASCADE,                          
        related_name='ratings'
    )

    article = models.ForeignKey(
        Article,
        on_delete=models.CASCADE,
        related_name='ratings'
    )

    value = models.IntegerField(choices=[(i, str(i)) for i in range(1, 6)])

    class Meta:
        verbose_name = 'Rating'
        verbose_name_plural = 'Ratings'
        unique_together = ('article', 'user')
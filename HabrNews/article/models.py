from django.db import models

class Article(models.Model):
    author = models.CharField(max_length=100)
    picture = models.ImageField(upload_to='article_pictures/') #(лучше хранить на https://cloudinary.com/)
    content = models.TextField()
    likes = models.IntegerField(default=0)  #надо сделать так, чтобы пользователь мог поставить только один лайк или дизлайк, и не мог менять свое мнение после этого. Для этого нужно создать отдельную модель для хранения информации о том, кто поставил лайк или дизлайк.
    dislikes = models.IntegerField(default=0) #надо сделать так, чтобы пользователь мог поставить только один лайк или дизлайк, и не мог менять свое мнение после этого. Для этого нужно создать отдельную модель для хранения информации о том, кто поставил лайк или дизлайк. 
    title = models.CharField(max_length=200)
    published_date = models.DateTimeField(auto_now_add=True)

    class Meta:
        verbose_name = 'Article'
        verbose_name_plural = 'Articles'
        ordering = ['-published_date']

    def __str__(self):
        return self.title


class Category(models.Model):
    name = models.CharField(max_length=30, unique=True)
    slug = models.SlugField(max_length=30, unique=True)

    class Meta:
        verbose_name = 'Category'
        verbose_name_plural = 'Categories'
        ordering = ['name']

    def __str__(self):
        return self.name
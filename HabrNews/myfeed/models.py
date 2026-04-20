from django.db import models

class Article(models.Model):
    author = models.CharField(max_length=100)
    picture = models.ImageField(upload_to='article_pictures/') #(лучше хранить на https://cloudinary.com/)
    content = models.TextField()
    likes = models.IntegerField(default=0)  #надо сделать так, чтобы пользователь мог поставить только один лайк или дизлайк, и не мог менять свое мнение после этого. Для этого нужно создать отдельную модель для хранения информации о том, кто поставил лайк или дизлайк.
    dislikes = models.IntegerField(default=0) #надо сделать так, чтобы пользователь мог поставить только один лайк или дизлайк, и не мог менять свое мнение после этого. Для этого нужно создать отдельную модель для хранения информации о том, кто поставил лайк или дизлайк. 
    title = models.CharField(max_length=200)
    published_date = models.DateTimeField(auto_now_add=True)

    CATEGORY_CHOICES = [
        ('prog', 'Programming'),
        ('design', 'Design'),
        ('other', 'Other'),
    ]

    category = models.CharField(max_length=30, choices=CATEGORY_CHOICES, default='prog')
from django import forms
from article.models import Article
# from django.core.exceptions import ValidationError


class ArticleForm(forms.ModelForm):
    class Meta:
        model = Article
        fields = ['title', 'content', 'picture', 'category']
        widgets = {
            'title': forms.TextInput(attrs={'class': 'form-control'}),
            'content': forms.Textarea(attrs={'class': 'form-control'}),
            'category': forms.Select(attrs={'class': 'form-control'}),
        }


# def clean_title(self):
#     title = self.cleaned_data.get('title')
#     if not title:
#         raise forms.ValidationError('Title is required.')
#     return title
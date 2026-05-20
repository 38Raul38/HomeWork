from django import forms
from django.core.exceptions import ValidationError


class ContactForm(forms.Form):
    name = forms.CharField(
        max_length=100,
        widget=forms.TextInput(
            attrs={"class": "form-control", "placeholder": "Your name"}
        ),
    )
    email = forms.EmailField(
        widget=forms.EmailInput(
            attrs={"class": "form-control", "placeholder": "name@example.com"}
        )
    )
    message = forms.CharField(
        widget=forms.Textarea(
            attrs={"class": "form-control", "rows": 4, "placeholder": "Your message"}
        )
    )


class NoteForm(forms.Form):
    CATEGORY_CHOICES = [
        ("study", "Study"),
        ("work", "Work"),
        ("personal", "Personal"),
    ]

    title = forms.CharField(
        max_length=100,
        widget=forms.TextInput(
            attrs={"class": "form-control", "placeholder": "Note title"}
        ),
    )
    content = forms.CharField(
        widget=forms.Textarea(
            attrs={
                "class": "form-control",
                "rows": 5,
                "placeholder": "Write your note content",
            }
        )
    )
    category = forms.ChoiceField(
        choices=CATEGORY_CHOICES,
        widget=forms.Select(attrs={"class": "form-select"}),
    )
    tags = forms.CharField(
        required=False,
        help_text="Use comma-separated tags",
        widget=forms.TextInput(
            attrs={"class": "form-control", "placeholder": "python, django, api"}
        ),
    )

    def clean_title(self):
        title = self.cleaned_data["title"].strip()
        if title.lower().startswith("test"):
            raise ValidationError("Title must not start with 'test'.")
        return title

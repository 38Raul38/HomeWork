from django.http import HttpResponse, HttpRequest
from django.shortcuts import render, redirect
from django.views.generic import TemplateView
from datetime import date

from notes import data
from notes.forms import ContactForm, NoteForm


class AboutPageView(TemplateView):
    template_name = 'notes/about.html'

    def get_context_data(self, **kwargs):
        context = super().get_context_data(**kwargs)
        context["project_name"] = "Knowledge Hub"
        context["author"] = "Nadir Zamanov"
        return context


def home(request: HttpRequest) -> HttpResponse:
    return render(request, "notes/home.html")


# def about(request: HttpRequest) -> HttpResponse:
#     context = {
#         "project_name": "Knowledge Hub",
#         "author": "Nadir Zamanov",
#     }
#     return render(request, "notes/about.html", context)


def notes_list(request: HttpRequest) -> HttpResponse:
    return render(request, "notes/notes_list.html",
                  {"page_title": "Notes List", "notes": data.TEMP_NOTES})


def note_detail(request: HttpRequest, note_id: int) -> HttpResponse:
    note = next((item for item in data.TEMP_NOTES if item["id"] == note_id), None)
    return render(request, "notes/note_detail.html", {"note": note})


def contact_page(request: HttpRequest) -> HttpResponse:
    if request.method == "POST":
        form = ContactForm(request.POST)
        if form.is_valid():
            return redirect("contact_success")
    else:
        form = ContactForm()
    return render(request, "contact.html", {"form": form})


def contact_success(request: HttpRequest) -> HttpResponse:
    return render(request, "contact_success.html")


def create_note(request: HttpRequest) -> HttpResponse:
    if request.method == "POST":
        form = NoteForm(request.POST)
        if form.is_valid():
            cleaned_data = form.cleaned_data
            next_id = max((item["id"] for item in data.TEMP_NOTES), default=0) + 1
            tags_value = cleaned_data.get("tags", "").strip()
            tags_list = [tag.strip() for tag in tags_value.split(",") if tag.strip()]

            data.TEMP_NOTES.append(
                {
                    "id": next_id,
                    "title": cleaned_data["title"],
                    "category": cleaned_data["category"],
                    "content": cleaned_data["content"],
                    "created_at": date.today().isoformat(),
                    "tags": tags_list,
                }
            )
            return redirect("notes:notes_list")
    else:
        form = NoteForm()
    return render(request, "create_note.html", {"form": form})
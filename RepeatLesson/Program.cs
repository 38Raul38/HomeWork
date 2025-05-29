using Lesson11;
using Lesson11.Data.Model;
using Lesson11.Implementations;
using Lesson11.Interfaces;

Menu menu = new();
IMovieService movieService = new MovieService();
FileService fileService = new FileService();

bool flag = true;

while (flag)
{
    menu.DisplayMenu();
    MenuChoice choice = menu.GetMenuChoice();

    switch (choice.Id)
    {
        case 1:
            Console.WriteLine($"You chose {choice.Description}");
            Console.Write("Enter movie name: ");
            var movieName = Console.ReadLine();

            var res = movieService.SearchMovie(movieName);
            Console.WriteLine(res);

            foreach (var movie in res.results)
            {
                Console.WriteLine(movie);
            }

            if (res.results.Length > 0)
            {
                Console.WriteLine("Saving first result...");
                fileService.Save(res.results[0]);
                Console.WriteLine("Movie saved.");
            }
            else
            {
                Console.WriteLine("No results found.");
            }
            break;

        case 2:
            Console.WriteLine($"You chose {choice.Description}");
            fileService.Delete();
            break;

        case 3:
            flag = false;
            Console.WriteLine("Exit");
            break;

        default:
            Console.WriteLine("Invalid choice");
            break;
    }

    Console.WriteLine();
}
Console.WriteLine("Goodbye!");
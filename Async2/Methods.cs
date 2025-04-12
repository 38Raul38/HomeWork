using ConsoleApp2.Context;
using ConsoleApp2.Data;

namespace ConsoleApp2;

public class Methods
{

    public class StudentManager
    {
        private AppDbContext _context;

        public StudentManager(AppDbContext context)
        {
            _context = context;
        }

        public void AddStudentManually(string name)
        {
            Task.Run(() =>
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Student can't be empty!");
                    return;
                }

                var student = new Student { Name = name };

                _context.Students.Add(student);
                _context.SaveChanges();

                Console.WriteLine($"Student {name} successful added");
            });
        }

        public void ShowAllStudentsManually()
        {
            var students = _context.Students.ToList();

            if (students.Count == 0)
            {
                Console.WriteLine("Strudent list is empty!");
            }
            else
            {
                Console.WriteLine("Student List");
                
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.Id}: {student.Name}");
                }
            }
        }
    }
}
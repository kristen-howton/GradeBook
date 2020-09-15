using System;
//need namespace to not conflict with MS
namespace Gradebook
{

    class Program
    {
        static void Main(string[] args)
        {

            //used to instantiate a class, contructor method
            InMemoryBook book = new InMemoryBook("Gradebook");

            book.GradeAdded += OneGradeAdded;
            EnterGrade(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"The book's name is {book.Name}");
            Console.WriteLine($"This is the highest grade {stats.High}");
            Console.WriteLine($"This is the lowest grade {stats.Low}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

        }

        private static void EnterGrade(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit.");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                var grade = double.Parse(input);
                book.AddGrade(grade);
            }
        }

        //book has no idea about this method
        static void OneGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }

    }
}
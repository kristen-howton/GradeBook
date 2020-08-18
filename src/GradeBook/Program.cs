using System;
//need namespace to not conflict with MS
namespace Gradebook
{

    class Program
    {
        static void Main(string[] args)
        {

            //used to instantiate a class, contructor method
            Book book = new Book("Gradebook");
            book.AddGrade(90.1);
            book.AddGrade(80.4);
            book.AddGrade(70.2);
            var stats = book.GetStatistics();

            Console.WriteLine($"This is the highest grade {stats.High}");
            Console.WriteLine($"This is the lowest grade {stats.Low}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

        }

    }
}
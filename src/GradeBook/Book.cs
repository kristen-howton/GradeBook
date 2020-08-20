using System;
using System.Collections.Generic;
using System.Linq;

namespace Gradebook
{
    //must use keyword delegate
    //usually take two parameters
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    //class is a blueprint
    public class Book

    {
        //fields are private
        private List<double> grades;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private string name;

        //contructor must have same name as class
        //public Book is an access modifier
        public Book(string name)
        {
            //should ignitate default values inside of contructors
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        //char lets it take a single character
        public void AddLetterGrade(char letter)
        {
            //switch kinda similar to an else if
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                case 'D':
                    AddGrade(60);
                    break;

                case 'F':
                    AddGrade(50);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        public Statistics GetStatistics()

        {

            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            var index = 0;
            while (index < grades.Count)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
                index++;
            }
            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                break;

                case var d when d >= 80.0:
                    result.Letter = 'B';
                break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                break;

                default:
                    result.Letter = 'F';
                    break;

            }
            return result;

        }

        //field on book class  
        public event GradeAddedDelegate GradeAdded;

    }

}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gradebook
{

    //class is a blueprint
    public class Book

    {
        //fields are private
        private List<double> grades;
        public string Name;

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
            grades.Add(grade);
        }

        public Statistics GetStatistics()

        {

            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (double grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;

            }
            result.Average /= grades.Count;
            return result;

        }
    }
}
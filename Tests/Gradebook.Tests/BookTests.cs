using System;
using Gradebook;
using Xunit;

namespace Gradebook.Tests
{
    //delegate are useful because you can point to different methods
    //new type can be used outside of this project
    //define varibables and fields
    public delegate string WriteLogDelegate(string logMesssage);
    public class BookTests
    {
        int count = 0;
        [Fact]
        public void WriteLogDeleageCantPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            //points to return message and can point to more than one method
            log += ReturnMessage;
            log += IncrementCount;
            var result = log("Hello");
            Assert.Equal("Hello", result);
            AssemblyLoadEventArgs.Equals(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message;
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        //let's file know this a a test
        [Fact]
        public void BookCalcuatesAverageGrade()
        {
            //arrage
            var book = new InMemoryBook("");

            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act

            var result = book.GetStatistics();

            //assert

            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
    }
}
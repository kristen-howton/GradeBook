using System;
using Gradebook;
using Xunit;

namespace Gradebook.Tests
{
    public class BookTests
    {
        //let's file know this a a test
        [Fact]
        public void BookCalcuatesAverageGrade()
        {
            //arrage
            var book = new Book("");

            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act

            var result = book.GetStatistics();

            //assert

            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
        }
    }
}
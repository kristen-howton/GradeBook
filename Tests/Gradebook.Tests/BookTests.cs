using System;
using Xunit;

namespace Gradebook.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void BookTests()
        {
            //arrage
            var book = new Book("");

            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act

            var result = book.ShowStatistics();

            //assert

            Assert.Equal(85.6, result.Average);
        }
    }
}
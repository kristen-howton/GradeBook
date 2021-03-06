using System;
using Gradebook;
using Xunit;

namespace Gradebook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "String";
            var upper = MakeUpperCase(name);
            Assert.Equal("String", name);
            Assert.Equal("STRING", upper);
        }

        private string MakeUpperCase(string name)
        {
            return name.ToUpper();

        }

        [Fact]
        public void SetIntFromValue()
        {
            var x = GetInt();

            SetInt(x);

            Assert.Equal(3, x);
        }

        private int SetInt(int x)
        {
            return 42;
        }

        [Fact]
        public void GetIntFromValue()
        {
            var x = GetInt();

            Assert.Equal(3, x);
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void PassByValue()
        {
            //arrage
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }
        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            book.Name = name;
        }

        [Fact]
        public void ChangingNameOfBook()
        {
            //arrage
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }
        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }
        //let's file know this a a test
        [Fact]
        public void VariablesReferenceDifferentObject()
        {
            //arrage
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void VariablesReferenceSameObject()
        {
            //arrage
            var book1 = GetBook("Book 1");
            //takes value in book1 and puts it in book2
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
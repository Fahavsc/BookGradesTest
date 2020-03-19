
using GradeBook;
using System;
using Xunit;

namespace Gradebook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            
            Assert.Equal("Book 2", book2.Name);
            Assert.Equal("Book 1", book1.Name);
        }

        [Fact]
        public void TwoVarPointedToTheSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            book2.Name = "Book 2";

            Assert.Equal(book2.Name, book1.Name);
            Assert.Equal("Book 2", book1.Name);
            Assert.Equal("Book 2", book2.Name);

            book1.Name = "Book 1";

            Assert.Equal(book2.Name, book1.Name);
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);

            var a = 3;
            var b = a;
            Assert.Equal(a, b);
            b = 4;

            Assert.Equal(3, a);
            Assert.Equal(4, b);
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}

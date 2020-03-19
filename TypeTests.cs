
using GradeBook;
using System;
using Xunit;

namespace Gradebook.Tests
{
    public class TypeTests
    {

        [Fact]
        public void Test1()
        {
            var x = GetInt();

            Assert.Equal(3, x);
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CanPassByRef()
        {
            var book1 = GetBook("Book 1");          
            GetBookSetNameByRef(out book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }

        void GetBookSetNameByRef(out Book book, string name)
        {
            //out obriga inicializar a variavel dentro do metodo
            book = new Book(name);
            book.AddGrade(0);
        }

        [Fact]
        public void PassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        void SetName(Book book, string name)
        {
            book.Name = name;
        }

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

            Assert.Same(book2.Name, book1.Name);
            Assert.Equal("Book 2", book1.Name);
            Assert.Equal("Book 2", book2.Name);

            book1.Name = "Book 1";

            Assert.Equal(book2.Name, book1.Name);
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);
            
            //Tipos primitivos
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

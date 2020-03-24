
using GradeBook;
using System;
using Xunit;

namespace Gradebook.Tests
{
    public class TypeTests
    {
        public delegate string WriteLogDelegate(string logMessage);

        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointoToMethod()
        {
            //O metodo que ira ser chamado deve ter o tipo de parametro e retorno igual declarado no delegate
            WriteLogDelegate log = ReturnMessage; //Passando uma função criada
            log += ReturnMessage;
            log += IncrementCount;

            Assert.Equal(0, count);
            //log = (string a) => { return a; }; //Arrow Fuction
            var result = log("Teste");
            Console.WriteLine(result);
            
            Assert.Equal(3 , count);
        }

        string IncrementCount(string message)
        {
            ++this.count;
            return message.ToLower();
        }

        string ReturnMessage(string message)
        {
            ++this.count;
            return message;
        }

        [Fact]
        public void ValieTypeAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
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
        public void StringsBahaveLikeValueType()
        {
            String name = "Fabricio";
            var upper = MakeUpperCase(name);

            Assert.Equal("FABRICIO", upper);
            Assert.Equal("Fabricio", name);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
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


using GradeBook;
using System;
using Xunit;

namespace Gradebook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //Arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act

            var stats = book.GetStatistics();
            book.ShowStatistics();


            //assert
            Assert.Equal(85.6, stats.Average, 1);
            Assert.Equal(77.3, stats.Low, 1) ;
            Assert.Equal(90.5, stats.High, 1);

        }
    }
}

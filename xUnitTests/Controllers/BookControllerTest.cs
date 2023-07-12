using FakeItEasy;
using FluentAssertions;
using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Controllers;
using LibraryAPI.Core.Entities.Dtos.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTests.Controllers
{
    public class BookControllerTest
    {
        private readonly IBookService _booksService;
        public BookControllerTest()
        {
            _booksService = A.Fake<IBookService>();
        }

        [Fact]
        public void BookController_GetBooksBrowse_ReturnOk()
        {
            //Arrage
            var controller = new BookController(_booksService);

            //Act
            var result = controller.GetBooksBrowse();

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void BookController_AddOrUpdateBook_ReturnOk()
        {
            //Arrage
            var book = A.Fake<BookAddOrUpdateDto>();
            book.Name = "TESTBOOK";
            book.Qty = 5;
            book.PageCount = 150;
            book.PubDate = DateTime.Now;
            book.Description = "testbookDesc";
            book.AuthorId = 2;
            book.CategoryId = 1;
            book.PublishingHouseId = 2;

            A.CallTo(()=> _booksService.AddOrUpdateBook(book)).Returns(ResultInfo.Success);
            var controller = new BookController(_booksService);

            //Act
            var result = controller.AddOrUpdateBook(book);

            //Assert
            result.Should().NotBeNull();
        }
    }
}

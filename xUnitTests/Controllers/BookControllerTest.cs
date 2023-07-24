using AutoFixture;
using Core.Utilities.Results;
using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Controllers;
using LibraryAPI.DataAccess.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTests.Controllers
{
    public class BookControllerTest
    {
        private readonly IFixture _fixture;
        private readonly Mock<IBookService> _serviceMock;
        private readonly BookController _controller;

        public BookControllerTest()
        {
            _fixture = new Fixture();
            _serviceMock = _fixture.Freeze<Mock<IBookService>>();
            _controller = new BookController(_serviceMock.Object);
        }

        //[Fact]
        //public Task GetBook_ShouldReturnOkResult_WhenValidId()
        //{
        //    //Arrage
        //    int id = _fixture.Create<int>();
        //    var bookMock = _fixture.Create<Book>();
        //    _serviceMock.Setup(x=> x.GetBookById(id)).Returns(bookMock);
        //    //Act

        //    //Assert

        //}
    }
}

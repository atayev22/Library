using AutoMapper;
using Core.Utilities.Results;
using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Core.Entities.Dtos.BookDtos;
using LibraryAPI.Core.Entities.Dtos.BorrowBookDtos;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Repositories.Abstract;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Concrete
{
    public class BorrowBookService : IBorrowBookService
    {
        private readonly IBorrowBookRepository _borrowBookRepository;
        private readonly IMapper _mapper;
        public BorrowBookService(IBorrowBookRepository borrowBookRepository, IMapper mapper)
        {
            _borrowBookRepository = borrowBookRepository;
            _mapper = mapper;
        }
        public ResultInfo AddOrUpdateBorrowBook(Reader reader)
        {
            throw new NotImplementedException();
        }

        public ResultInfo DeleteBorrowBook(int id)
        {
            throw new NotImplementedException();
        }

        public Result GetBorrowBooksBrowse()
        {
            var result = new Result();
            var response = _borrowBookRepository.GetBorrowBooksBrowse();
            var data = from bb in response
                       select new BorrowBookBrowseDto
                       {
                           Id = bb.Id,
                           LendDate = bb.LendDate,
                           ReturnDate = bb.ReturnDate,
                           BookName = bb.Book.Name,
                           ReaderFullName = string.Concat(bb.Reader.FirstName, " ", bb.Reader.LastName)
                       };
            result.Data = data;
            return result;
        }

        public Result GetBorrowBooksByBookId(int bookId)
        {
            var result = new Result();
            var response = _borrowBookRepository.GetBorrowBooksByBookId(bookId);
            var data = from bb in response
                       select new BorrowBookBrowseDto
                       {
                           Id = bb.Id,
                           LendDate = bb.LendDate,
                           ReturnDate = bb.ReturnDate,
                           BookName = bb.Book.Name,
                           ReaderFullName = string.Concat(bb.Reader.FirstName, " ", bb.Reader.LastName)
                       };
            result.Data = data;
            return result;
        }

        public Result GetBorrowBooksByDateInterval(DateTime date1, DateTime date2)
        {
            throw new NotImplementedException();
        }

        public Result GetBorrowBooksByReaderId(int readreId)
        {
            var result = new Result();
            var response = _borrowBookRepository.GetBorrowBooksByReaderId(readreId);
            var data = from bb in response
                       select new BorrowBookBrowseDto
                       {
                           Id = bb.Id,
                           LendDate = bb.LendDate,
                           ReturnDate = bb.ReturnDate,
                           BookName = bb.Book.Name,
                           ReaderFullName = string.Concat(bb.Reader.FirstName, " ", bb.Reader.LastName)
                       };
            result.Data = data;
            return result;
        }
    }
}

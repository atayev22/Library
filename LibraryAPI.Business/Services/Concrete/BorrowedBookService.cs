using AutoMapper;
using Core.Utilities.Results;
using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Core.Entities.Dtos.BookDtos;
using LibraryAPI.Core.Entities.Dtos.BorrowBookDtos;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Repositories.Abstract;
using LibraryAPI.DataAccess.Repositories.Concrete;
using MimeKit;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Concrete
{
    public class BorrowedBookService : IBorrowedBookService
    {
        private readonly IBorrowedBookRepository _borrowBookRepository;
        private readonly IMapper _mapper;
        public BorrowedBookService(IBorrowedBookRepository borrowBookRepository, IMapper mapper)
        {
            _borrowBookRepository = borrowBookRepository;
            _mapper = mapper;
        }
        public ResultInfo AddOrUpdateBorrowedBook(BorrowedBookDto borrowBook)
        {
            var data = _mapper.Map<BorrowedBook>(borrowBook);
            if (data.Id is 0)
            {
                _borrowBookRepository.Add(data);
            }
            else
            {
                _borrowBookRepository.Update(data);
            }

            if (data is null)
            {
                return ResultInfo.NotImplemented;
            }

            return ResultInfo.Success;
        }

        public ResultInfo DeleteBorrowedBook(int id)
        {
            var response = _borrowBookRepository.Delete(id);
            if (response is false)
            {
                return ResultInfo.NotFound;
            }
            return ResultInfo.Deleted;
        }

        public Result GetBorrowedBooksBrowse()
        {
            var result = new Result();
            var response = _borrowBookRepository.GetBorrowedBooksBrowse();
            var data = from bb in response
                       select new BorrowedBookBrowseDto
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

        public Result GetBorrowedBooksByBookId(int bookId)
        {
            var result = new Result();
            var response = _borrowBookRepository.GetBorrowedBooksByBookId(bookId);
            var data = from bb in response
                       select new BorrowedBookBrowseDto
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

        public Result GetBorrowedBooksByDateInterval(DateTime firstDate, DateTime secondDate)
        {
            var result = new Result();

            var response = _borrowBookRepository.GetBorrowedBooksByDateInterval(firstDate, secondDate);
            var data = _mapper.Map<IEnumerable<GetBorrowedBooksByDateIntervalDto>>(response.ToList());

            result.Data = data;
            return result;
        }

        public Result GetBorrowedBooksByReaderId(int readreId)
        {
            var result = new Result();
            var response = _borrowBookRepository.GetBorrowedBooksByReaderId(readreId);
            var data = from bb in response
                       select new BorrowedBookBrowseDto
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

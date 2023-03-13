using AutoMapper;
using Core.Utilities.Results;
using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Core.Entities.Dtos.BorrowBookDtos;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Repositories.Abstract;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var response = _borrowBookRepository.GetBorrowBooksBrowse().ToList();
            var data = from bb in response
                       select new
                       {
                           bb.Id,
                           bb.LendDate,
                           bb.ReturnDate,
                           BookName = bb.Book.Name,
                           ReaderFullName = string.Concat(bb.Reader.FirstName, " ", bb.Reader.LastName)
                       };
            result.Data = _mapper.Map<List<BorrowBookBrowseDto>>(data);
            return result;
        }

        public Result GetBorrowBookByBookId(int bookId)
        {
            throw new NotImplementedException();
        }

        public Result GetBorrowBooksByDateInterval(DateTime date1, DateTime date2)
        {
            throw new NotImplementedException();
        }

        public Result GetBorrowBookByReaderId(int readreId)
        {
            throw new NotImplementedException();
        }
    }
}

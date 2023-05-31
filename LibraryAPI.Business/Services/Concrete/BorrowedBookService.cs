using AutoMapper;
using Core.Utilities.Results;
using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Core.Entities.Dtos.BookDtos;
using LibraryAPI.Core.Entities.Dtos.BorrowBookDtos;
using LibraryAPI.Core.Entities.SpModels;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Infrastructure.Tools.EfCore;
using LibraryAPI.DataAccess.Repositories.Abstract;
using LibraryAPI.DataAccess.Repositories.Concrete;
using LibraryAPI.DataAccess.Utilities.EMail;
using Microsoft.Data.SqlClient;
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
        private readonly IBookRepository _bookRepository;
        private readonly IReaderRepository _readerRepository;
        private readonly IMapper _mapper;
        public BorrowedBookService(IBorrowedBookRepository borrowBookRepository,IBookRepository bookRepository, IReaderRepository readerRepository, IMapper mapper)
        {
            _borrowBookRepository = borrowBookRepository;
            _readerRepository = readerRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public ResultInfo AddOrUpdateBorrowedBook(BorrowedBookDto borrowBook)
        {
            var bookResponse = _bookRepository.Get(borrowBook.BookId);
            var data = _mapper.Map<BorrowedBook>(borrowBook);

            if (bookResponse.Qty is 0)
            {
                return ResultInfo.BlockedOperation;
            }
            else
            {
                if (data.Id is 0)
                {
                    _borrowBookRepository.Add(data);
                    bookResponse.Qty -= 1;
                    _bookRepository.Update(bookResponse);
                }
                else
                {
                    _borrowBookRepository.Update(data);
                }
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

        public ResultInfo SendMailToReader(int readerId)
        {
            string htmlBody = "";
            var response = _readerRepository.Get(readerId);
            string subject = "Книги которые вы взяли";

            htmlBody += @$"<!DOCTYPE html>
                        <html>
                        <head>
                        	<meta charset=""utf-8"">
                        	<meta name=""viewport"" content=""width=device-width, initial-scale=1"">
                        	<title></title>
                        </head>
                        <body>
                        <div style=""border: 3px solid darkorange;margin: 10px 10px 10px 10px;padding: 10px 10px 10px 10px;"">
	             <table width=""100%"">
	             	<tr>
	             		<th>
	             			<img width=""100px"" height=""100px"" src=""https://sun6-22.userapi.com/s/v1/ig2/fzFMJC2Zy12BCRru7n0L7Sne7lWDSPaWPX5Ou0BAVMhIsTMyn6O65AhpgNvYwq1KbhCh_MDjRBHlTgPgFOWb2z1A.jpg?size=1218x1220&quality=95&crop=0,0,1218,1220&ava=1"">
	             		</th>
	             		<th>
	             			<p>Спасибо что выбрали нашу Библиотеку</p>
	             		</th>
	             	</tr>
	             </table>
	             <table id = ""materiasId"" class=""table table-striped"" style=""font-size:14px; width: 100%;"">
                <thead style = ""border:2px solid darkorange;"" >
              <tr>
                <th width = ""15%"" style=""background-color: darkorange; color: black;border:1px solid darkorange;"">Book Name</th>
                <th width = ""15%"" style= ""background-color: darkorange; color: black;border:1px solid darkorange;"" >Lend Date </th>           
                  <th width= ""15%"" style= ""background-color: darkorange; color: black;border:1px solid darkorange;"" >Return Date</th>      
                </tr>            
              </thead>  
                <tbody style= ""border:2px solid darkorange;"" >";           

            var data = _borrowBookRepository.GetBorrowedBooksByReaderId(readerId);
            foreach (var book in data)
            {
                htmlBody += $@"<tr>
                <th width = ""15%"" style="" color: black;border:1px solid darkorange;"">{book.Book.Name}</th>
                <th width = ""15%"" style= "" color: black;border:1px solid darkorange;"" >{book.LendDate.ToString("dd-MM-yyyy")}</th>           
                <th width= ""15%"" style= "" color: black;border:1px solid darkorange;"" >{book.ReturnDate.ToString("dd-MM-yyyy")}</th>      
                </tr>";
            }
            htmlBody += $@"</tbody>		
	                        </table>
                           </div>
                        </body>
                    </html>";

            return EmailKit.SendMail(response.Email, subject, htmlBody);
        }
    }
}

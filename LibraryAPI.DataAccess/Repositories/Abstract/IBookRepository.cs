using LibraryAPI.Core.Entities.Dtos.Book;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Repositories.Abstract
{
    public interface IBookRepository : IEntityBaseRepository<Book>
    {
        Book GetByIdWithAllRelations(int id);
        IQueryable<Book> GetBooksBrowse();     
    }
}

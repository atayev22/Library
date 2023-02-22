using AutoMapper;
using LibraryAPI.DataAccess.Context;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Concrete;
using LibraryAPI.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Repositories.Concrete
{
    public class ReaderRepository : EntityBaseRepository<Reader>, IReaderRepository
    {
        public ReaderRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public IQueryable<Reader> GetReaderByContact(string number)
        {
            var data = dbSet.
                Where(r => r.Contact.Contains(number));
            return data;
        }

        public IQueryable<Reader> GetReaderByName(string name)
        {
            var data = dbSet.
                Where(r=> string.Concat(r.FirstName, r.LastName).
                Contains(name));
            return data;
        }
    }
}

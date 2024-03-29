﻿using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Repositories.Abstract
{
    public interface IReaderRepository: IEntityBaseRepository<Reader>
    {
        IQueryable<Reader> GetReaderByName(string name);
        IQueryable<Reader> GetReaderByContact(string number);
    }
}

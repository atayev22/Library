﻿using AutoMapper;
using LibraryAPI.Core.Entities.Models;
using LibraryAPI.DataAccess.Context;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Abstract;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Concrete;
using LibraryAPI.DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Repositories.Concrete
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public User GetUserByUserName(string userName)
        {
            var data = dbSet.Where(un => un.UserName == userName).Include(r => r.UserRole).FirstOrDefault();
            if (data is null)
            {
                return null;
            }

            return data;
        }
    }
}

using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Business.Services.Concrete;
using LibraryAPI.DataAccess.Context;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Abstract;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Concrete;
using LibraryAPI.DataAccess.Repositories.Abstract;
using LibraryAPI.DataAccess.Repositories.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Utilities.DependencyResolvers
{
    public static class ProjectDependencies
    {
        public static void AddProjectDependencies(this IServiceCollection services)
        {
            // Services
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IReaderService, ReaderService>();
            services.AddScoped<IBorrowedBookService, BorrowedBookService>();
            services.AddScoped<IUserService, UserService>();

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IReaderRepository, ReaderRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBorrowedBookRepository, BorrowedBookRepository>();
            services.AddScoped(typeof(IEntityBaseRepository<>), typeof(EntityBaseRepository<>));

            //OnConfiguring
            services.AddDbContext<AppDbContext>();

        }
    }
}

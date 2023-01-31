using LibraryAPI.DataAccess.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryAPI.DataAccess
{
    public class AppDbContext : DbContext
    {
        protected AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<BorrowedBooks> BorrowedBooks { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<PublishingHouses> PublishingHouses { get; set; }
        public DbSet<Readers> Readers { get; set; }
    }
}

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
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=UNISER-KAMRAN\\SQLEXPRESS;Database=DB_Library;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Books
            modelBuilder.Entity<Books>().HasOne<Authors>(a => a.Author);
            modelBuilder.Entity<Books>().HasOne<Categories>(a => a.Category);
            modelBuilder.Entity<Books>().HasOne<PublishingHouses>(a => a.PublishingHouse);
            #endregion

            #region BorrowedBooks
            modelBuilder.Entity<BorrowedBooks>().HasOne<Books>(a => a.Book);
            modelBuilder.Entity<BorrowedBooks>().HasOne<Readers>(a => a.Reader);
            #endregion
        }

        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<BorrowedBooks> BorrowedBooks { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<PublishingHouses> PublishingHouses { get; set; }
        public DbSet<Readers> Readers { get; set; }
    }
}

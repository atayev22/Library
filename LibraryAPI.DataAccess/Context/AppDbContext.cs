using LibraryAPI.Core.Entities.FnModels;
using LibraryAPI.Core.Entities.Models;
using LibraryAPI.Core.Entities.SpModels;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryAPI.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
                optionsBuilder.UseSqlServer($"Server=UNISER-KAMRAN\\SQLEXPRESS;Database=DB_Library;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Books
            modelBuilder.Entity<Book>().HasOne(a => a.Author);
            modelBuilder.Entity<Book>().HasOne(a => a.Category);
            modelBuilder.Entity<Book>().HasOne(a => a.PublishingHouse);
            #endregion

            #region BorrowedBooks
            modelBuilder.Entity<BorrowedBook>().HasOne(a => a.Book);
            modelBuilder.Entity<BorrowedBook>().HasOne(a => a.Reader);
            #endregion


            #region HasNoKey(FN,SP)
            //var classTypes = AppDomain.CurrentDomain.GetAssemblies()
            //           .SelectMany(t => t.GetTypes())
            //           .Where(t => t.IsClass && t.Name.StartsWith("SP_") || t.Name.StartsWith("FN_"))
            //           .ToHashSet();
            //foreach (var type in classTypes)
            //{
            //    modelBuilder.Entity(type).HasNoKey();
            //}
            #endregion

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

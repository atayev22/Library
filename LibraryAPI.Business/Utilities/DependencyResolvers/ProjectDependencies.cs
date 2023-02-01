using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Business.Services.Concrete;
using LibraryAPI.DataAccess;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Abstract;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Concrete;
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
            services.AddScoped<IBooksService,BookService>();

            //Repositories
            services.AddScoped(typeof(IEntityBaseRepository<>), typeof(EntityBaseRepository<>));

            //OnConfiguring

            services.AddDbContext<AppDbContext>();


  //          "ConnectionStrings": {
  //              "DefaultConnection": "Server=UNISER-KAMRAN\\SQLEXPRESS;Database=DB_Library;Trusted_Connection=True;TrustServerCertificate=True;"
  //},
        }
    }
}

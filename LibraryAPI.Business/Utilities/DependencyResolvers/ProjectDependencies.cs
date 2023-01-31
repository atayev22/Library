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


            //Repositories
            services.AddScoped(typeof(IEntityBaseRepository<>), typeof(EntityBaseRepository<>));
        }
    }
}

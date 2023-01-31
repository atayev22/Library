using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Infrastructure.Repositories.Abstract
{
    public interface IEntityBaseRepository
    { }
    public interface IEntityBaseRepository<TEntity> : IEntityBaseRepository
    {
         IQueryable<TEntity> GetAll();
         TEntity Get(int id);
         void Add(TEntity entity);
         void Update(TEntity entity);
         bool Delete(int id); 
    }
}

using AutoMapper;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Infrastructure.Repositories.Concrete
{
    public class EntityBaseRepository : IEntityBaseRepository
    {
        protected AppDbContext _dbContext;
        protected IMapper _mapper;

        public EntityBaseRepository(AppDbContext dbContext,IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }
    }
    public class EntityBaseRepository<TEntity> : EntityBaseRepository, IEntityBaseRepository<TEntity> where TEntity : class,new()
    {
        protected DbSet<TEntity> dbSet;
        public EntityBaseRepository(AppDbContext dbContext,IMapper mapper) : base(dbContext,mapper)
        {
            this.dbSet = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var data = Get(id);
            if (data != null)
            {
                dbSet.Remove(data);
                _dbContext.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }

        }

        public IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public TEntity Get(int id)
        {         
            var data = dbSet.Find(id);
         
            return data;
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
            _dbContext.SaveChanges();    
        }
    }
}

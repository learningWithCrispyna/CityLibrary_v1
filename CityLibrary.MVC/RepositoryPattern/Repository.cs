using CityLibrary.MVC.DbContext;
using CityLibrary.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CityLibrary.MVC.RepositoryPattern
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected DbSet<T> _dbSet;
        private CityLibraryDbContext _dbContext;

        public Repository(CityLibraryDbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
            _dbContext = dbContext;
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        
        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetEntity(int id)
        {
            return _dbSet.Where(x => x.Id == id);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            var entry = _dbContext.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Dispose()
        {
        }

    }
}
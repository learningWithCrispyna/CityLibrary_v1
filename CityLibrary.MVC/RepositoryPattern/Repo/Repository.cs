﻿using CityLibrary.MVC.DbContext;
using CityLibrary.MVC.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace CityLibrary.MVC.RepositoryPattern
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private DbSet<T> _dbSet;
        protected CityLibraryDbContext _dbContext;

        public Repository(CityLibraryDbContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
            _dbContext = dbContext;
        }

        public virtual void Create(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
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
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
        }

    }
}
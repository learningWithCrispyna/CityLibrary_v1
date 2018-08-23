﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityLibrary.MVC.RepositoryPattern
{
    public interface IRepository<T> : IDisposable
    {
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> GetEntity(int id);
    }
}
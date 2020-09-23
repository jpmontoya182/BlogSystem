using Blog.Models.DataBase;
using Blog.Repos.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Repos
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly BlogBDContext _DbContext;
        private readonly DbSet<T> _DbSet;

        public GenericRepository(BlogBDContext context)
        {
            _DbContext = context;
            _DbSet = _DbContext.Set<T>();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

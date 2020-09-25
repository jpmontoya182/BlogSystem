using Blog.Models.DataBase;
using Blog.Repos.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<T> GetAll()
        {
            return _DbSet.ToList();
        }

        public T GetById(int id)
        {
            return _DbSet.Find(id);
        }

        public void Add(T entity)
        {
            _DbSet.Add(entity);
        }


        public void Update(T entity)
        {
            _DbSet.Attach(entity);
            _DbContext.Entry(entity).State = EntityState.Modified;

        }

        public void Delete(T entity)
        {
            _DbSet.Remove(entity);
        }


    }
}

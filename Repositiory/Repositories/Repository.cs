using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Contracts;
using Data;
using GUNAAPugetSound.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected GunaaDbContext RepositoryContext { get; set; }
        protected readonly DbSet<T> DbSet;

        protected RepositoryBase(GunaaDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
            DbSet = RepositoryContext.Set<T>();
        }
        public IQueryable<T> FindAll()
        {
            return DbSet.AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            DbSet.Add(entity);
        }
        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }
    }
}
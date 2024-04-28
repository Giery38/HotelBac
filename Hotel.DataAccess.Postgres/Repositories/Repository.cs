﻿using Hotel.Core.Extensions;
using Hotel.DataAccess.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.DataAccess
{
    public class Repository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext? dbContext;
        protected readonly DbSet<TEntity>? dbSet;
        public Repository(DbContext dbContext)
        {
            dbSet = dbContext.GetDbSetProperties(new Type[] { typeof(TEntity) })[0].GetValue(dbContext) as DbSet<TEntity>;            
        }
        #region GET
        public async Task<List<TEntity>> Get()
        {          
            return await dbSet
                .AsNoTracking()                
                .ToListAsync();
        }
        public async Task<TEntity> Get(Guid id)
        {
            return await dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(item => item.Id == id);
        }
        public async Task<List<TEntity>> Get(Expression<Func<TEntity, object>>[] includeProperties) //GetWithInclude(x=>x.Company.Name.StartsWith("S"), p=>p.Company); https://metanit.com/sharp/entityframework/3.13.php
        {
            IQueryable<TEntity> query = dbSet.AsNoTracking();
            IQueryable<TEntity> result = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await result.ToListAsync();
        }
        #endregion
        #region ADD
        public virtual async Task Add(TEntity item) 
        {
            await dbSet.AddAsync(item);
            await dbContext.SaveChangesAsync();            
        }     
        #endregion
        #region UPDATE
        public async Task Update<TProperty>(Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls, Guid id)
        {
            await dbSet
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(setPropertyCalls);
        }
        #endregion
        #region DELETE
        public async Task Delete(Guid id)
        {
            await dbSet
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();            
        }
        #endregion     
    }
}
 
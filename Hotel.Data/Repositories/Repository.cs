using Hotel.Core.Extensions;
using Hotel.Core.Models.Common;
using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Z.Linq;

namespace Hotel.Data
{
    public class Repository<TEntity> : IRepositoryAsync<TEntity> where TEntity : Entity
    {
        #region CTOR
        protected readonly HotelDbContext? dbContext;
        protected DbSet<TEntity>? dbSet;
        public Repository(HotelDbContext dbContext, DbSet<TEntity> dbSet)
        {
            this.dbContext = dbContext;
            this.dbSet = dbSet;
        }
        #endregion 
        #region GET      
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
        #region GETALL
        public async Task<List<TEntity>> GetAll()
        {
            return await dbSet
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<List<TEntity>> GetAll(Predicate<TEntity> predicate)
        {
            List<TEntity> entities = dbSet.AsNoTracking().ToList();
            return entities.FindAll(predicate);
        }
        #endregion
        #region ADD
        public async Task Add(TEntity item)
        {
            await dbSet.AddAsync(item);
            await dbContext.SaveChangesAsync();
        }
        #endregion
        #region UPDATE

        public async Task Update(TEntity item)
        {
            dbSet.Update(item);
            await dbContext.SaveChangesAsync();

        }
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
 
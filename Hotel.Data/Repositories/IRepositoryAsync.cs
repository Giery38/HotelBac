using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Hotel.Data
{
    public interface IRepositoryAsync<TEntity> where TEntity : Entity
    {
        Task Add(TEntity item);

        Task Delete(Guid id);

        Task<List<TEntity>> Get(Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity> Get(Guid id);

        Task<List<TEntity>> GetAll();

        Task<List<TEntity>> GetAll(Predicate<TEntity> predicate);

        Task Update(TEntity item);

        Task Update<TProperty>(Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls, Guid id);
    }
}
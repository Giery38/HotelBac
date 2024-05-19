using Hotel.Core.Models.Common;
using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Hotel.Application.Services.Data.Common
{
    public interface IRepositoryServiceAsync<TEntity, TModel>
        where TEntity : Entity
        where TModel : Model
    {
        Task Add(TModel item);
        Task Delete(Guid id);
        Task<List<TModel>> Get(Expression<Func<TEntity, object>>[] includeProperties);
        Task<TModel> Get(Guid id);
        Task<List<TModel>> GetAll();
        Task<List<TModel>> GetAll(Predicate<TEntity> predicate);
        Task Update(TModel item);
        Task Update<TProperty>(Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls, Guid id);
    }
}
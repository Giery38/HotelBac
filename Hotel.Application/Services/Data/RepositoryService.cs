using Hotel.Application.Converters;
using Hotel.Core.Models.Common;
using Hotel.Data;
using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Z.Linq;

namespace Hotel.Application.Services.Data
{
    public class RepositoryService<TEntity, TModel> : IRepositoryServiceAsync<TEntity, TModel>
        where TEntity : Entity
        where TModel : Model
    {
        private readonly IRepositoryAsync<TEntity> repository;
        public RepositoryService(IRepositoryAsync<TEntity> repository)
        {
            this.repository = repository;
        }
        #region GET
        public async Task<TModel> Get(Guid id)
        {
            TEntity model = await repository.Get(id);
            return model.ToModel() as TModel;

        }
        public async Task<List<TModel>> Get(Expression<Func<TEntity, object>>[] includeProperties)
        {
            List<TEntity> entities = await repository.Get(includeProperties);
            return (List<TModel>)await entities.ConvertAll(item => item.ToModel()).CastAsync<TModel>();
        }
        #endregion
        #region GETALL
        public async Task<List<TModel>> GetAll()
        {
            List<TEntity> entities = await repository.GetAll();           
            return await entities.ConvertAll(item => item.ToModel()).CastAsync<TModel>().ToList();
        }
        public async Task<List<TModel>> GetAll(Predicate<TEntity> predicate)
        {
            List<TEntity> entities = await repository.GetAll(predicate);
            return (List<TModel>)await entities.ConvertAll(item => item.ToModel()).CastAsync<TModel>();
        }
        #endregion
        #region ADD
        public async Task Add(TModel item)
        {                
            await repository.Add(item.ToEntity() as TEntity);
        }
        #endregion
        #region UPDATE
        public async Task Update(TModel item)
        {
            await repository.Update(item.ToEntity() as TEntity);
        }
        public async Task Update<TProperty>(Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> setPropertyCalls, Guid id)
        {
            await repository.Update<TProperty>(setPropertyCalls, id);
        }
        #region DELETE
        public async Task Delete(Guid id)
        {
            await repository.Delete(id);
        }
        #endregion
        #endregion
    }
}
 
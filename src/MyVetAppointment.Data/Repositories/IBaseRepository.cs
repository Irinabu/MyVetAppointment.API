﻿using System.Linq.Expressions;

namespace MyVetAppointment.Data.Repositories
{

    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity?> GetFirstLazyLoad(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes);

        Task<IQueryable<TEntity>> GetAllLazyLoad(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(TEntity entity);
        Task<bool> SaveChangesAsync();
    }
}
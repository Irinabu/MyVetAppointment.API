﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyVetAppointment.Data.Persistence;

namespace MyVetAppointment.Data.Repositories.Implementations
{

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DatabaseContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected BaseRepository(DatabaseContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = (await DbSet.AddAsync(entity)).Entity;
            await Context.SaveChangesAsync();

            return addedEntity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var removedEntity = DbSet.Remove(entity).Entity;
            await Context.SaveChangesAsync();

            return removedEntity;
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<IQueryable<TEntity>> GetAllLazyLoad(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes)
        {
            await Task.Run(() => includes.ToList().ForEach(x => DbSet.Include(x).Load()));
            return DbSet;
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {

            return (await DbSet.Where(predicate).FirstOrDefaultAsync())!;
        }

        public async Task<TEntity?> GetFirstLazyLoad(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes)
        {
            includes.ToList().ForEach(x => DbSet.Include(x).Load());
            return await DbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync() > 0;
        }
    }
}
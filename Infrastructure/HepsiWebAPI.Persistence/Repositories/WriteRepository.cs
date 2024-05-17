﻿using HepsiWebAPI.Application.Interfaces.Repositories;
using HepsiWebAPI.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HepsiWebAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext dbContext;

        public WriteRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task AddAsync(T entity)
        {
            await dbContext.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await dbContext.AddRangeAsync(entities);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }

        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }
    }
}

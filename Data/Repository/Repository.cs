using Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void DeleteById(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public async Task InsertOrUpdate(IEnumerable<T> entities)
        {
            using var transaction = await _appDbContext.Database.BeginTransactionAsync();
            try
            {
                var entitiesToInsert = entities.Where(e => IsNewEntity(e));
                var entitiesToUpdate = entities.Where(e => !IsNewEntity(e));

                if (entitiesToUpdate.Any())
                {
                    await _dbSet.AddRangeAsync(entitiesToInsert);
                }
                if (entitiesToUpdate.Any())
                {
                    _dbSet.UpdateRange(entitiesToUpdate);
                }

                await _appDbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private bool IsNewEntity(T entity)
        {
            var prop = typeof(T).GetProperty("Id");
            if (prop == null)
                throw new InvalidOperationException("Entity must have an Id Property");

            var value = prop.GetValue(entity);
            return value is int intvalue && intvalue == 0;
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}

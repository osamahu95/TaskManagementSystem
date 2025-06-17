using Domain.Interface;
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

        public void InsertOrUpdate(IEnumerable<T> entities)
        {
            using var transaction = _appDbContext.Database.BeginTransaction();
            try
            {
                foreach(var entity in entities)
                {
                    var entityEntry = _appDbContext.Entry(entity);
                    if(entityEntry.State == EntityState.Detached)
                    {
                        _dbSet.Add(entity);
                    }
                    else if(entityEntry.State == EntityState.Modified)
                    {
                        _dbSet.Update(entity);
                    }
                }

                _appDbContext.SaveChanges();
                transaction.Commit();
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}

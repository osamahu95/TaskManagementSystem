using TaskApi.Domain.Interface;
using TaskApi.Domain.Interface.Repository;
using TaskApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public ITaskRepository TaskRepository { get; }
        public IUserRepository UsersRepository { get; }
        
        public UnitOfWork(AppDbContext appDbContext, ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _appDbContext = appDbContext;
            TaskRepository = taskRepository;
            UsersRepository = userRepository;
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }

        public async System.Threading.Tasks.Task SaveChanges()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}

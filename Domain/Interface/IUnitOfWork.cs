using TaskApi.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApi.Domain.Interface
{
    public interface IUnitOfWork: IDisposable
    {
        ITaskRepository TaskRepository { get; }
        IUserRepository UsersRepository { get; }
        Task SaveChanges();
    }
}

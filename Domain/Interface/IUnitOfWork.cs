﻿using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUnitOfWork: IDisposable
    {
        ITaskRepository TaskRepository { get; }
        IUserRepository UsersRepository { get; }
        Task SaveChanges();
    }
}

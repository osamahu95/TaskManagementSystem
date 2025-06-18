using TaskApi.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class TaskRepository: Repository<TaskApi.Domain.Models.Task>, ITaskRepository
    {
        private readonly AppDbContext _appDbContext;

        public TaskRepository(AppDbContext appDbContext): base(appDbContext)
        {
            _appDbContext = appDbContext;    
        }
    }
}

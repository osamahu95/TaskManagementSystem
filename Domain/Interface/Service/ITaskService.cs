using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Service
{
    public interface ITaskService
    {
        Task<IEnumerable<Domain.Models.Task>> GetAllTasks();
        Task<Domain.Models.Task> GetTaskById(int Id);
        Task<Domain.Models.Task> CreateTask(TaskInputViewModel taskInputViewModel);
    }
}

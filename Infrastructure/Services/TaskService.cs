using Domain.Interface;
using Domain.Interface.Service;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Domain.Models.Task> CreateTask(TaskInputViewModel taskInputViewModel)
        {
            Domain.Models.Task task = new Domain.Models.Task()
            {
                Title = taskInputViewModel.Title,
                IsCompleted = taskInputViewModel.IsCompleted,
                UserId = taskInputViewModel.AssignedUser
            };
            await _unitOfWork.TaskRepository.Add(task);
            await _unitOfWork.SaveChanges();

            return task;
        }

        public async Task<IEnumerable<Domain.Models.Task>> GetAllTasks()
        {
            return await _unitOfWork.TaskRepository.GetAll();
        }

        public async Task<Domain.Models.Task> GetTaskById(int Id)
        {
            return await _unitOfWork.TaskRepository.GetById(Id);
        }
    }
}

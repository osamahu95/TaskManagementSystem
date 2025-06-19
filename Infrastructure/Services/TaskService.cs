using TaskApi.Domain.Interface;
using TaskApi.Domain.Interface.Service;
using TaskApi.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApi.Domain.Interface.Validators;
using TaskApi.Infrastructure.Events;

namespace TaskApi.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnumerable<ITaskValidator> _taskValidators;

        public delegate void TaskCreatedHandler(Domain.Models.Task task);
        public event TaskCreatedHandler TaskCreated;

        public TaskService(IUnitOfWork unitOfWork, IEnumerable<ITaskValidator> taskValidators)
        {
            _unitOfWork = unitOfWork;
            _taskValidators = taskValidators;

            // Subscribe to the TaskCreated event if needed
            TaskCreated += TasksEvent.HandleTaskCreated; // Example of subscribing to the event
        }

        public async Task<Domain.Models.Task> CreateTask(TaskInputViewModel taskInputViewModel)
        {
            Domain.Models.Task task = new Domain.Models.Task()
            {
                Title = taskInputViewModel.Title,
                IsCompleted = taskInputViewModel.IsCompleted,
                UserId = taskInputViewModel.AssignedUser
            };
            foreach(var validator in _taskValidators)
            {
                if (!validator.Validate(task, out string errorMessage))
                {
                    throw new ArgumentException(errorMessage);
                }
            }

            await _unitOfWork.TaskRepository.Add(task);
            await _unitOfWork.SaveChanges();

            // Trigger the event after task creation
            TaskCreated?.Invoke(task);

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

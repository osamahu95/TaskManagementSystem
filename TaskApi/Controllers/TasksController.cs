using Domain.Interface;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TasksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.TaskRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskInputViewModel taskInputViewModel)
        {
            Domain.Models.Task task = new Domain.Models.Task()
            {
                Title = taskInputViewModel.Title,
                IsCompleted = taskInputViewModel.IsCompleted,
                UserId = taskInputViewModel.AssignedUser
            };
            await _unitOfWork.TaskRepository.Add(task);
            await _unitOfWork.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);
        }
    }
}

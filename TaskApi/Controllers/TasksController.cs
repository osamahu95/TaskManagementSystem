using Domain.Interface.Service;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Filters;

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogActionFilter))] // Applying the Log action filter
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(TimeLoggingFilter))] // Applying the Time Log action filter
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _taskService.GetTaskById(id));
        }

        [HttpGet]
        [ServiceFilter(typeof(TimeLoggingFilter))] // Applying the Time Log action filter
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _taskService.GetAllTasks());
        }

        [HttpPost]
        [ServiceFilter(typeof(TimeLoggingFilter))] // Applying the Time Log action filter
        public async Task<IActionResult> Create(TaskInputViewModel taskInputViewModel)
        {
            var createdTask = await _taskService.CreateTask(taskInputViewModel);
            return CreatedAtAction(nameof(GetAll), new { id = createdTask.Id }, createdTask);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApi.Infrastructure.Events
{
    public class TasksEvent
    {
        public static void HandleTaskCreated(Domain.Models.Task task)
        {
            // Logic to handle task creation event
            Debug.WriteLine($"Task Created: {task.Title} at {DateTime.Now}.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApi.Domain.Interface.Validators;

namespace TaskApi.Infrastructure.Validators
{
    public class AdminTaskValidator : ITaskValidator
    {
        public bool Validate(Domain.Models.Task task, out string errorMessage)
        {
            if (string.IsNullOrEmpty(task.Title))
            {
                errorMessage = "Task title cannot be empty.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}

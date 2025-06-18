using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApi.Domain.Interface.Validators;

namespace TaskApi.Infrastructure.Validators
{
    public class UserTaskValidator : ITaskValidator
    {
        public bool Validate(Domain.Models.Task task, out string errorMessage)
        {
            if (task.UserId == 0)
            {
                errorMessage = "Task must be assigned to a user.";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }
    }
}

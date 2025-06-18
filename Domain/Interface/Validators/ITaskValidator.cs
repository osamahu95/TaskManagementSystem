using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApi.Domain.Interface.Validators
{
    public interface ITaskValidator
    {
        bool Validate(Models.Task task, out string errorMessage);
    }
}

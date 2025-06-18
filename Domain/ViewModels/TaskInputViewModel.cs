using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApi.Domain.ViewModels
{
    public class TaskInputViewModel
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public int AssignedUser { get; set; }
    }
}

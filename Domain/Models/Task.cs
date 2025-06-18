using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApi.Domain.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        // Navigation Properties
        public int UserId { get; set; }
        public User AssignedUser { get; set; }
    }
}

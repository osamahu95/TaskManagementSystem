using TaskApi.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApi.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoleEnum Role { get; set; }
        public List<Task> Tasks { get; set; }
    }
}

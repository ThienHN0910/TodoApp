using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Application.DTOs
{
    public class TaskDTO
    {
        public string Name { get; set; } = null!;

        public DateOnly CreatedAt { get; set; }

        public DateOnly Deadline { get; set; }

        public string Priority { get; set; } = null!;

        public bool Status { get; set; }
    }
}

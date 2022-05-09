using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Core.Enums;

namespace Core.Entities
{
    [Table("Tasks")]
    public class MyTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public int Priority { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
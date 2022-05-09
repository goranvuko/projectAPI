using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Projects;

namespace Core.DTOs.Tasks
{
    public class MyTaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TaskStatus { get; set; }
        public int Priority { get; set; }
        public int ProjectId { get; set; }
        public ProjectDto Project { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Tasks;

namespace Core.DTOs.Projects
{
    public class UpdateProjectDto : CreateProjectDto
    {
        public int Id { get; set; }
        public int ProjectStatus { get; set; }
        public List<int> Tasks { get; set; }
    }
}
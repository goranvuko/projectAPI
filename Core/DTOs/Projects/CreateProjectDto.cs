using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTOs.Projects
{
    public class CreateProjectDto
    {   
        [Required]
        public string Name { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime CompletionDate { get; set; }

        [Required]
        public int Priority { get; set; }
    }
}
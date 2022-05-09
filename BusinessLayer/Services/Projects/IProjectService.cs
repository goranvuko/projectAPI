using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Projects;

namespace BusinessLayer.Services.Projects
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> GetProjects();
        Task<ProjectDto> GetProject(int id);
        Task<ProjectDto> CreateProject(CreateProjectDto createProjectDto);
        Task<ProjectDto> UpdateProject(UpdateProjectDto updateProjectDto);
        Task DeleteProject(int id);
    }
}
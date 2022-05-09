using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services.Projects;
using Core.DTOs.Projects;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProjectsController : BaseApiController
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> GetProjects()
        {
            var projects = await _projectService.GetProjects();

            return (projects == null) ?
                NotFound() :
                Ok(projects);
        }

        [HttpGet("{id}")] // http://localhost:5000/api/projects/1
        public async Task<ActionResult<ProjectDto>> GetProject([FromRoute] int id)
        {
            var project = await _projectService.GetProject(id);

            return (project == null) ?
                NotFound() :
                Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateProject([FromBody] CreateProjectDto createProjectDto)
        {
            var project = await _projectService.CreateProject(createProjectDto);

            return (project == null) ?
                NotFound() :
                Created("Project is successfully created!", project);
        }

        // todo
        [HttpPut("{id}")]
        public async Task<ActionResult<ProjectDto>> UpdateProject([FromRoute] int id, [FromBody] UpdateProjectDto updateProjectDto)
        {
            if (id != updateProjectDto.Id) {
                return BadRequest("Ids are not the same!");
            }
            
            var project = await _projectService.UpdateProject(updateProjectDto);
        
            return (project == null) ?
                NotFound() :
                Ok(project);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject([FromRoute] int id)
        {   
            await _projectService.DeleteProject(id);

            return NoContent();
        }
    }
}
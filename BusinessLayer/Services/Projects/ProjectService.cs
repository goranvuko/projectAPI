using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Projects;
using Core.Entities;
using EFCore.Repositories.Projects;
using EFCore.Repositories.Tasks;

namespace BusinessLayer.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository projectRepository, ITaskRepository taskRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<ProjectDto>> GetProjects()
        {
            return _mapper.Map<List<ProjectDto>>(await _projectRepository.GetProjects());
        }

        
        public async Task<ProjectDto> GetProject(int id)
        {
            return _mapper.Map<ProjectDto>(await _projectRepository.GetProject(id));
        }

        public async Task<ProjectDto> CreateProject(CreateProjectDto createProjectDto)
        {
            return _mapper.Map<ProjectDto>(await _projectRepository.CreateProject(_mapper.Map<Project>(createProjectDto)));
        }

        public async Task<ProjectDto> UpdateProject(UpdateProjectDto updateProjectDto) // tasks: [5, 6]
        {
            var project = await _projectRepository.GetProject(updateProjectDto.Id); // find project in database first
            var projectToUpdate = _mapper.Map<UpdateProjectDto, Project>(updateProjectDto, project); // update existing project with a new project from our request body
            projectToUpdate.Tasks = null;
            
            foreach(var taskId in updateProjectDto.Tasks)
            {
                var task = await _taskRepository.GetTask(taskId);
                if (task != null) {
                    projectToUpdate.Tasks.Add(task);
                }
            }
            

            return _mapper.Map<ProjectDto>(await _projectRepository.UpdateProject(projectToUpdate)); // object that returns from database needs to be converted to a ProjectDto object before sending to service layer 
        }

        public async Task DeleteProject(int id)
        {
            await _projectRepository.DeleteProject(id);
        }
    }
}
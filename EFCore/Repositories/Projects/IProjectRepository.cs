using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace EFCore.Repositories.Projects
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetProjects();
        Task<Project> GetProject(int id);
        Task<Project> CreateProject(Project project);
        Task<Project> UpdateProject(Project project);
        Task DeleteProject(int id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repositories.Projects
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;
        public ProjectRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetProjects()
        {
            return await _context.Projects.Include(p => p.Tasks).ToListAsync();
        }

        public async Task<Project> GetProject(int id)
        {
            return await _context.Projects.Include(p => p.Tasks).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project> CreateProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<Project> UpdateProject(Project project)
        {
            // searching through a database for an existing project with the same id field value and when it finds it, it corrects it's own values with the values of our project received from the service layer
            _context.Projects.Update(project); 
            await _context.SaveChangesAsync();

            return await GetProject(project.Id);
        }

        public async Task DeleteProject(int id)
        {
            var project = await GetProject(id);

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}
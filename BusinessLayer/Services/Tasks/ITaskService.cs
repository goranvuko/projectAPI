using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Tasks;

namespace BusinessLayer.Services.Tasks
{
    public interface ITaskService
    {
        Task<List<MyTaskDto>> GetTasks();
        Task<MyTaskDto> GetTask(int id);
        Task<MyTaskDto> CreateTask(CreateTaskDto createTaskDto);
        Task<MyTaskDto> UpdateTask(UpdateTaskDto updateTaskDto);
        Task DeleteTask(int id);
        Task<List<MyTaskDto>> GetProjectTasks(int projectId);
    }
}
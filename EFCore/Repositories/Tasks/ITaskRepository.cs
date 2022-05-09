using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace EFCore.Repositories.Tasks
{
    public interface ITaskRepository
    {
        Task<List<MyTask>> GetTasks();
        Task<MyTask> GetTask(int id);
        Task<MyTask> CreateTask(MyTask task);
        Task<MyTask> UpdateTask(MyTask myTask);
        Task DeleteTask(int id);
        Task<List<MyTask>> GetProjectTasks(int projectId);
    }
}
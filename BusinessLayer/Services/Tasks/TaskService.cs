using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Tasks;
using Core.Entities;
using EFCore.Repositories.Tasks;

namespace BusinessLayer.Services.Tasks
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<MyTaskDto>> GetTasks()
        {
            return _mapper.Map<List<MyTaskDto>>(await _taskRepository.GetTasks());
        }
        
        public async Task<MyTaskDto> GetTask(int id)
        {
            return _mapper.Map<MyTaskDto>(await _taskRepository.GetTask(id));
        }

        public async Task<MyTaskDto> CreateTask(CreateTaskDto createTaskDto)
        {
            return _mapper.Map<MyTaskDto>(await _taskRepository.CreateTask(_mapper.Map<MyTask>(createTaskDto)));
        }

        public async Task<MyTaskDto> UpdateTask(UpdateTaskDto updateTaskDto)
        {
            var task = await _taskRepository.GetTask(updateTaskDto.Id);
            var taskToUpdate = _mapper.Map<UpdateTaskDto, MyTask>(updateTaskDto, task);
            return _mapper.Map<MyTaskDto>(await _taskRepository.UpdateTask(_mapper.Map<MyTask>(taskToUpdate)));
        }

        public async Task DeleteTask(int id)
        {
            await _taskRepository.DeleteTask(id);
        }

        public async Task<List<MyTaskDto>> GetProjectTasks(int projectId)
        {
            return _mapper.Map<List<MyTaskDto>>(await _taskRepository.GetProjectTasks(projectId));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services.Tasks;
using Core.DTOs.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TasksController : BaseApiController
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<MyTaskDto>> GetTasks()
        {
            var tasks = await _taskService.GetTasks();

            return (tasks == null) ?
                NotFound() :
                Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MyTaskDto>> GetTask([FromRoute] int id)
        {
            var task = await _taskService.GetTask(id);

            return (task == null) ?
                NotFound() :
                Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<MyTaskDto>> CreateTask([FromBody] CreateTaskDto createTaskDto)
        {
            var task = await _taskService.CreateTask(createTaskDto);

            return (task == null) ?
                NotFound() :
                Created("Task is successfully created!", task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MyTaskDto>> UpdateTask([FromRoute] int id, [FromBody] UpdateTaskDto updateTaskDto)
        {
            if (id != updateTaskDto.Id) {
                return BadRequest("Ids are not the same!");
            }

            var task = await _taskService.UpdateTask(updateTaskDto);

            return (task == null) ?
                NotFound() :
                Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask([FromRoute] int id)
        {
            await _taskService.DeleteTask(id);

            return NoContent();
        }

        [HttpGet("/project/{projectId}")] // http://localhost:5000/api/tasks/project/1
        public async Task<ActionResult<List<MyTaskDto>>> GetProjectTasks([FromRoute] int projectId) 
        {
            var tasks = await _taskService.GetProjectTasks(projectId);

            return (tasks == null) ?
                NotFound() :
                Ok(tasks);
        }
    }
}
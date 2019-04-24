using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracking.Api.Infrastructure.Services.Interfaces;
using BugTracking.Models.Requests;
using BugTracking.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BugTracking.Api.Controllers
{
    // Tasks controller
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // POST api/tasks
        [HttpPost("GetAll")]
        public async Task<ActionResult<List<TaskResponse>>> GetAll([FromBody] TasksRequest tasksRequest)
        {
            return await _taskService.GetTasksAsync(tasksRequest);
        }

        // GET api/tasks/id
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskResponse>> Get(int id)
        {
            return await _taskService.GetTaskAsync(id);
        }

        // POST api/tasks
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TaskAddRequest addTaskRequest)
        {
            return await _taskService.AddTaskAsync(addTaskRequest);
        }

        // PUT api/tasks/id
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TaskChangeRequest taskChangeRequest)
        {
            return await _taskService.ChangeTaskAsync(id, taskChangeRequest);
        }

        // DELETE api/tasks/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await _taskService.DeleteTaskAsync(id);
        }
    }
}

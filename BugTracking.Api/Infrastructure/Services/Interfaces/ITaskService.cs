using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracking.Models.Requests;
using BugTracking.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BugTracking.Api.Infrastructure.Services.Interfaces
{
    public interface ITaskService
    {
        Task<ActionResult<List<TaskResponse>>> GetTasksAsync(TasksRequest tasksRequest);
        Task<ActionResult<TaskResponse>> GetTaskAsync(int id);
        Task<ActionResult> AddTaskAsync(TaskAddRequest addTaskRequest);
        Task<ActionResult> ChangeTaskAsync(int id, TaskChangeRequest taskChangeRequest);
        Task<ActionResult> DeleteTaskAsync(int id);
    }
}

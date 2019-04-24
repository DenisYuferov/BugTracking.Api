using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BugTracking.Models.Requests;
using BugTracking.Models.Responses;

namespace BugTracking.Api.Infrastructure.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ActionResult<List<ProjectResponse>>> GetProjectsAsync();
        Task<ActionResult<ProjectResponse>> GetProjectAsync(int id);
        Task AddProjectAsync(ProjectRequest projectRequest);
        Task<ActionResult> ChangeProjectAsync(int id, ProjectRequest projectRequest);
        Task<ActionResult> DeleteProjectAsync(int id);
        Task<ActionResult<List<TaskResponse>>> GetTasksByProjectIdAsync(int id);
    }
}

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
        Task<ActionResult<ProjectResponse>> GetProjectByIdAsync(uint id);
        Task AddProjectAsync(ProjectRequest projectRequest);
        Task ChangeProjectAsync(uint id, ProjectRequest projectRequest);
        Task DeleteProjectAsync(uint id);
    }
}

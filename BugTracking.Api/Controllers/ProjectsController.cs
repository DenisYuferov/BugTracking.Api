using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracking.Api.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BugTracking.Models.Requests;
using BugTracking.Models.Responses;

namespace BugTracking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET api/projects
        [HttpGet]
        public async Task<ActionResult<List<ProjectResponse>>> Get()
        {
            return await _projectService.GetProjectsAsync();
        }

        // GET api/projects/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectResponse>> Get(uint id)
        {
            return await _projectService.GetProjectByIdAsync(id);
        }

        // POST api/projects
        [HttpPost]
        public async Task Post([FromBody] ProjectRequest value)
        {
            await _projectService.AddProjectAsync(value);
        }

        // PUT api/projects/id
        [HttpPut("{id}")]
        public async Task Put(uint id, [FromBody] ProjectRequest value)
        {
            await _projectService.ChangeProjectAsync(id, value);
        }

        // DELETE api/projects/id
        [HttpDelete("{id}")]
        public async Task Delete(uint id)
        {
            await _projectService.DeleteProjectAsync(id);
        }
    }
}

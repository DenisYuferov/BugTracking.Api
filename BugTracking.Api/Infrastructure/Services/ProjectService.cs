using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BugTracking.Api.Infrastructure.Repository;
using BugTracking.Api.Infrastructure.Services.Interfaces;
using BugTracking.Models.Requests;
using BugTracking.Models.Responses;

namespace BugTracking.Api.Infrastructure.Services
{
    /// <summary> Project service </summary>
    public class ProjectService : IProjectService
    {
        private readonly ProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IMapper mapper,
                              ProjectRepository projectRepository)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
        }
        /// <summary> Get projects </summary>
        public async Task<ActionResult<List<ProjectResponse>>> GetProjectsAsync()
        {
            var projectList = await _projectRepository.All().ToListAsync();

            var projectResponseList = _mapper.Map<List<ProjectResponse>>(projectList);

            return projectResponseList;
        }

        /// <summary> Get project </summary>
        public async Task<ActionResult<ProjectResponse>> GetProjectAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null) return new NotFoundObjectResult($"Project is not found with id:{id}");
            
            var projectResponse = _mapper.Map<ProjectResponse>(project);

            return projectResponse;
        }

        /// <summary> Add project </summary>
        public async Task AddProjectAsync(ProjectRequest projectRequest)
        {
            var project = _mapper.Map<Models.Project>(projectRequest);

            await _projectRepository.InsertAsync(project);
        }

        /// <summary> Change project </summary>
        public async Task<ActionResult> ChangeProjectAsync(int id, ProjectRequest projectRequest)
        {
            var project = _mapper.Map<Models.Project>(projectRequest);

            var result = await _projectRepository.UpdateProjectById(id, project);

            if (!result) return new NotFoundObjectResult($"Project is not found with id:{id}");

            return new OkResult();
        }

        /// <summary> Delete project </summary>
        public async Task<ActionResult> DeleteProjectAsync(int id)
        {
            var result = await _projectRepository.DeleteByIdAsync(id);

            if (!result) return new NotFoundObjectResult($"Project is not found with id:{id}");

            return new OkResult();
        }

        /// <summary> Get tasks by project id </summary>
        public async Task<ActionResult<List<TaskResponse>>> GetTasksByProjectIdAsync(int id)
        {
            var project = await _projectRepository.GetProjectByIdWithTasksAsync(id);

            if (project == null) return new NotFoundObjectResult($"Project is not found with id:{id}");

            var taskResponseList = _mapper.Map<List<TaskResponse>>(project.Tasks);

            return taskResponseList;
        }
    }
}

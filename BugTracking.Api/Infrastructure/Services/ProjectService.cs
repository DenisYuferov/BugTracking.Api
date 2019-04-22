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

        public async Task<ActionResult<List<ProjectResponse>>> GetProjectsAsync()
        {
            var projectList = await _projectRepository.All().ToListAsync();

            var projectResponseList = _mapper.Map<List<ProjectResponse>>(projectList);

            return projectResponseList;
        }

        public async Task<ActionResult<ProjectResponse>> GetProjectByIdAsync(uint id)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            var projectResponse = _mapper.Map<ProjectResponse>(project);

            return projectResponse;
        }

        public async Task AddProjectAsync(ProjectRequest projectRequest)
        {
            var project = _mapper.Map<Models.Project>(projectRequest);

            await _projectRepository.InsertAsync(project);
        }

        public async Task ChangeProjectAsync(uint id, ProjectRequest projectRequest)
        {
            var project = _mapper.Map<Models.Project>(projectRequest);

            await _projectRepository.UpdateProjectById(id, project);
        }

        public async Task DeleteProjectAsync(uint id)
        {
            await _projectRepository.DeleteByIdAsync(id);
        }
    }
}

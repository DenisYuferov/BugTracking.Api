using System.Threading.Tasks;
using BugTracking.Api.Infrastructure.Repository.Interfaces;
using BugTracking.Data;
using BugTracking.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace BugTracking.Api.Infrastructure.Repository
{
    public class ProjectRepository : BaseRepository<Project, BugTrackingDbContext>, IProjectRepository
    {
        public ProjectRepository(BugTrackingDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<Project> GetProjectByIdWithTasksAsync(uint id)
        {
            return await DbContext.Projects.Include(t => t.Tasks).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateProjectById(uint id, Project modifiedProject)
        {
            var project = await GetByIdAsync(id);

            project.Name = modifiedProject.Name;
            project.Description = modifiedProject.Description;
            project.Tasks = modifiedProject.Tasks;

            await UpdateAsync(project);
        }
    }
}

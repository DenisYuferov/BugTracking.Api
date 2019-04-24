using System.Threading.Tasks;
using BugTracking.Api.Infrastructure.Repository.Interfaces;
using BugTracking.Data;
using Microsoft.EntityFrameworkCore;

namespace BugTracking.Api.Infrastructure.Repository
{
    public class ProjectRepository : BaseRepository<Models.Project, BugTrackingDbContext>, IProjectRepository
    {
        public ProjectRepository(BugTrackingDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<Models.Project> GetProjectByIdWithTasksAsync(int id)
        {
            return await DbContext.Projects.Include(t => t.Tasks).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> UpdateProjectById(int id, Models.Project modifiedProject)
        {
            var project = await GetByIdAsync(id);

            if (project == null) return false;
            
            project.Name = modifiedProject.Name;
            project.Description = modifiedProject.Description;

            await UpdateAsync(project);

            return true;
        }
    }
}

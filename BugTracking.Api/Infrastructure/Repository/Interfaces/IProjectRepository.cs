using System.Threading.Tasks;

namespace BugTracking.Api.Infrastructure.Repository.Interfaces
{
    public interface IProjectRepository
    {
        Task<Models.Project> GetProjectByIdWithTasksAsync(uint id);
        Task UpdateProjectById(uint id, Models.Project project);
    }
}

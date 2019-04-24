using System.Threading.Tasks;

namespace BugTracking.Api.Infrastructure.Repository.Interfaces
{
    public interface IProjectRepository
    {
        Task<Models.Project> GetProjectByIdWithTasksAsync(int id);
        Task<bool> UpdateProjectById(int id, Models.Project project);
    }
}

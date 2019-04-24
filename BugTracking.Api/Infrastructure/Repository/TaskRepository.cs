using BugTracking.Api.Infrastructure.Repository.Interfaces;
using BugTracking.Data;

namespace BugTracking.Api.Infrastructure.Repository
{
    public class TaskRepository : BaseRepository<Models.Task, BugTrackingDbContext>, ITaskRepository
    {
        public TaskRepository(BugTrackingDbContext dbContext) : base(dbContext)
        {

        }
    }
}
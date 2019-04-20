using Microsoft.EntityFrameworkCore;
using BugTracking.Models;

namespace BugTracking.Data
{
    public class BugTrackingDbContext : DbContext
    {
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public BugTrackingDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}

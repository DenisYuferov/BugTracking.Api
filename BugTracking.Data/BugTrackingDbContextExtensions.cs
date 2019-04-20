using System.Collections.Generic;
using System.Linq;
using BugTracking.Models;

namespace BugTracking.Data
{
    public static class BugTrackingDbContextExtensions
    {
        public static void SeedDataBase(this BugTrackingDbContext dbContext)
        {
            if (dbContext.Statuses.FirstOrDefault() == null)
            {
                dbContext.Statuses.AddRange(new List<Status>
                {
                    new Status{Name = "НОВАЯ"},
                    new Status{Name = "В РАБОТЕ"},
                    new Status{Name = "ЗАКРЫТА"}
                });

                dbContext.SaveChanges();
            }
        }
    }
}

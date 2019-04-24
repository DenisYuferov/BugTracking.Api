using System;

namespace BugTracking.Models.Requests
{
    public class TasksRequest
    {
        public DateTime? FilterByCreationDateStart { get; set; }
        public DateTime? FilterByCreationDateEnd { get; set; }

        public DateTime? FilterByModificationDateStart { get; set; }
        public DateTime? FilterByModificationDateEnd { get; set; }

        public int ? FilterByPriority { get; set; }
        public int ? FilterByStatusId { get; set; }

        public bool? SortByCreationDateAsc { get; set; }
        public bool? SortByModificationDateAsc { get; set; }
        public bool? SortByPriorityAsc { get; set; }
    }
}

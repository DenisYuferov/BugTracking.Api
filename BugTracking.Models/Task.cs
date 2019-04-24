using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracking.Models
{
    [Table("Tasks")]
    public class Task : BaseModelExtended
    {
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int Priority { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracking.Models
{
    [Table("Tasks")]
    public class Task : BaseModelExtended
    {
        public uint ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public uint Priority { get; set; }
        public uint StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
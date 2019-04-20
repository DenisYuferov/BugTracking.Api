using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracking.Models
{
    [Table("Tasks")]
    public class Task : BaseModel
    {
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint Priority { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
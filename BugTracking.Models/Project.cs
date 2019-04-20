using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracking.Models
{
    [Table("Projects")]
    public class Project : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Task> Tasks { get; set; }
    }
}
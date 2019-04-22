using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracking.Models
{
    [Table("Projects")]
    public class Project : BaseModelExtended
    {
        public virtual List<Task> Tasks { get; set; }
    }
}
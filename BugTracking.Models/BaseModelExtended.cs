using System;

namespace BugTracking.Models
{
    public class BaseModelExtended : BaseModel
    {
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}

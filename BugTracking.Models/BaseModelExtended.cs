using System;

namespace BugTracking.Models
{
    public class BaseModelExtended : BaseModel
    {
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BugTracking.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

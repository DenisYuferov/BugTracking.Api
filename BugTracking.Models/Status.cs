using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracking.Models
{
    [Table("Statuses")]
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
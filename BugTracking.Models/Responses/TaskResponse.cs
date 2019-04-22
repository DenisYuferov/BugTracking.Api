namespace BugTracking.Models.Responses
{
    public class TaskResponse : BaseModelExtended
    {
        public uint ProjectId { get; set; }
        public uint Priority { get; set; }
        public uint StatusId { get; set; }
    }
}

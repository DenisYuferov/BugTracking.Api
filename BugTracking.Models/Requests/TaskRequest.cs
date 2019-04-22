namespace BugTracking.Models.Requests
{
    public class TaskRequest : BaseRequest
    {
        public uint ProjectId { get; set; }
        public uint Priority { get; set; }
        public uint StatusId { get; set; }
    }
}

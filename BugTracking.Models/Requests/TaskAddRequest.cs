namespace BugTracking.Models.Requests
{
    public class TaskAddRequest : BaseRequest
    {
        public int ProjectId { get; set; }
        public int Priority { get; set; }
    }
}

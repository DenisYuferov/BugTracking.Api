namespace BugTracking.Models.Requests
{
    public class TaskChangeRequest : BaseRequest
    {
        public int StatusId { get; set; }
    }
}

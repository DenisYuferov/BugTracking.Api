namespace BugTracking.Models.Responses
{
    public class TaskResponse : BaseModelExtended
    {
        public int ProjectId { get; set; }
        public int Priority { get; set; }
        public int StatusId { get; set; }
    }
}

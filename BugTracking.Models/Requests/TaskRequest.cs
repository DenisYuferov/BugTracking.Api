﻿namespace BugTracking.Models.Requests
{
    public class TaskRequest : TaskAddRequest
    {
        public int StatusId { get; set; }
    }
}

using AutoMapper;
using BugTracking.Models;
using BugTracking.Models.Requests;
using BugTracking.Models.Responses;

namespace BugTracking.Api.Infrastructure.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskAddRequest, Task> ();
            CreateMap<Task, TaskResponse>();
        }
    }
}

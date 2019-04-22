﻿using AutoMapper;
using BugTracking.Models;
using BugTracking.Models.Requests;
using BugTracking.Models.Responses;

namespace BugTracking.Api.Infrastructure.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectRequest>();
            CreateMap<Project, ProjectResponse>();
        }
    }
}

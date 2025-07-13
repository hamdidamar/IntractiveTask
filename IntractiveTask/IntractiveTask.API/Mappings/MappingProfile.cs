using AutoMapper.Features;
using AutoMapper;
using Azure;
using IntractiveTask.Entity.Dtos.ProjectDtos;
using IntractiveTask.Entity.Dtos.TaskDtos;
using IntractiveTask.Entity.Dtos.UserDtos;
using IntractiveTask.Entity.Entities;
using System.Diagnostics.Metrics;
using System;

namespace IntractiveTask.API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        #region Project

        CreateMap<ProjectDto, Project>().ReverseMap();
        CreateMap<ProjectCreateDto, Project>().ReverseMap();
        CreateMap<ProjectUpdateDto, Project>().ReverseMap();
        CreateMap<ProjectDeleteDto, Project>().ReverseMap();

        #endregion

        #region ProjectTask

        CreateMap<ProjectTaskDto, ProjectTask>().ReverseMap();
        CreateMap<ProjectTaskCreateDto, ProjectTask>().ReverseMap();
        CreateMap<ProjectTaskUpdateDto, ProjectTask>().ReverseMap();
        CreateMap<ProjectTaskDeleteDto, ProjectTask>().ReverseMap();

        #endregion

        #region User

        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<UserCreateDto, User>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();
        CreateMap<UserDeleteDto, User>().ReverseMap();

        #endregion


    }
}

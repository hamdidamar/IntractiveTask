using AutoMapper;
using IntractiveTask.API.Controllers.Base;
using IntractiveTask.Entity.Dtos.ProjectDtos;
using IntractiveTask.Entity.Entities;
using IntractiveTask.Entity.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace IntractiveTask.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProjectController : BaseController<Project, ProjectDto, ProjectCreateDto, ProjectUpdateDto, ProjectDeleteDto>
{
    public ProjectController(IManager<Project> manager, IMapper mapper, ICacheService cacheService) : base(manager, mapper, cacheService)
    {
    }
}

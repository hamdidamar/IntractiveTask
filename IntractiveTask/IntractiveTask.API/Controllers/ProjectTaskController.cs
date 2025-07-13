using AutoMapper;
using IntractiveTask.API.Controllers.Base;
using IntractiveTask.Entity.Dtos.TaskDtos;
using IntractiveTask.Entity.Entities;
using IntractiveTask.Entity.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace IntractiveTask.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ProjectTaskController : BaseController<ProjectTask, ProjectTaskDto, ProjectTaskCreateDto, ProjectTaskUpdateDto, ProjectTaskDeleteDto>
{
    public ProjectTaskController(IManager<ProjectTask> manager, IMapper mapper, ICacheService cacheService) : base(manager, mapper, cacheService)
    {
    }
}

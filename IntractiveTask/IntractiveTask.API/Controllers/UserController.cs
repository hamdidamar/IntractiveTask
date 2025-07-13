using AutoMapper;
using IntractiveTask.API.Controllers.Base;
using IntractiveTask.Entity.Dtos.UserDtos;
using IntractiveTask.Entity.Entities;
using IntractiveTask.Entity.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace IntractiveTask.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController<User, UserDto, UserCreateDto, UserUpdateDto, UserDeleteDto>
{
    public UserController(IManager<User> manager, IMapper mapper, ICacheService cacheService) : base(manager, mapper, cacheService)
    {
    }
}
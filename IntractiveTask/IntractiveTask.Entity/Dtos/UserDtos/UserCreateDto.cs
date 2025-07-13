using IntractiveTask.Entity.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntractiveTask.Entity.Dtos.UserDtos;

public class UserCreateDto : BaseCreateDto
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public int UserTypeId { get; set; }
}

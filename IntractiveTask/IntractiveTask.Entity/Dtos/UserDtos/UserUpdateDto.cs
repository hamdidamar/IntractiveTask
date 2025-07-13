using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntractiveTask.Entity.Dtos.Base;

namespace IntractiveTask.Entity.Dtos.UserDtos;

public class UserUpdateDto : BaseUpdateDto
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public int UserTypeId { get; set; }
}

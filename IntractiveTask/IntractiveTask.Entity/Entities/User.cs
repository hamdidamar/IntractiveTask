using IntractiveTask.Entity.Entities.Base;
using IntractiveTask.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntractiveTask.Entity.Entities;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public int UserTypeId { get; set; }
}

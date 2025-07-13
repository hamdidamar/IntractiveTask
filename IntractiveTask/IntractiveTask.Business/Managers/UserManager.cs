using IntractiveTask.Business.Managers.Base;
using IntractiveTask.Entity.Entities;
using IntractiveTask.Entity.Interfaces.Base;
using IntractiveTask.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntractiveTask.Business.Managers;

public class UserManager : BaseManager<User>, IUserManager
{
    public UserManager(IRepository<User> repository) : base(repository)
    {
    }
}
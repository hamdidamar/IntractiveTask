using IntractiveTask.Entity.Entities;
using IntractiveTask.Entity.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntractiveTask.Entity.Interfaces;

public interface IUserManager : IManager<User>
{
    string Authenticate(string username, string password);
    bool VerifyPassword(string password, string storedHash);
}
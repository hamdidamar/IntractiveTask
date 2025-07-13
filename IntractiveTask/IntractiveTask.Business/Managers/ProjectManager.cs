using IntractiveTask.Business.Managers.Base;
using IntractiveTask.Entity.Entities;
using IntractiveTask.Entity.Interfaces;
using IntractiveTask.Entity.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntractiveTask.Business.Managers;

public class ProjectManager : BaseManager<Project>, IProjectManager
{
    public ProjectManager(IRepository<Project> repository) : base(repository)
    {
    }
}

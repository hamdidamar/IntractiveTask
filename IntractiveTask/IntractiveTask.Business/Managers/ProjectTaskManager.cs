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

public class ProjectTaskManager : BaseManager<ProjectTask>, IProjectTaskManager
{
    public ProjectTaskManager(IRepository<ProjectTask> repository) : base(repository)
    {
    }
}
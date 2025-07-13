using IntractiveTask.Entity.Entities.Base;
using IntractiveTask.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntractiveTask.Entity.Entities;

public class ProjectTask : BaseEntity
{
    public int ProjectId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ProjectTaskStatusEnum Status { get; set; }
    public ProjectTaskPriorityEnum Priority { get; set; }

    public virtual Project Project { get; set; }
}

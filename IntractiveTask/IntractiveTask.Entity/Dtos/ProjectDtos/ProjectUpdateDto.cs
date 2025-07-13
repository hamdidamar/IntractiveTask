using IntractiveTask.Entity.Dtos.Base;
using IntractiveTask.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntractiveTask.Entity.Dtos.ProjectDtos;

public class ProjectUpdateDto : BaseUpdateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ProjectStatusEnum Status { get; set; }
}

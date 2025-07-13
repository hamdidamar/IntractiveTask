using IntractiveTask.Entity.Entities;
using IntractiveTask.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntractiveTask.Data.Seeders;

public class ProjectTaskSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectTask>().HasData(
            new ProjectTask
            {
                Id = 1,
                ProjectId = 1,
                Title = "Initial Setup",
                Description = "Set up the project structure and initial configurations.",
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(5),
                Status = ProjectTaskStatusEnum.NotStarted,
                Priority = ProjectTaskPriorityEnum.Medium,
                CreatedById = 1,
            }
        );
    }

   
}

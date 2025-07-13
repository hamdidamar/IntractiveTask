using IntractiveTask.Entity.Entities;
using IntractiveTask.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntractiveTask.Data.Seeders;

public class ProjectSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = 1, 
                Title = "Project Management System",
                Description = "A system to manage projects effectively.",
                StartDate = DateTime.Now.AddDays(1),
                CreatedById = 1,
                CreatedDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(30),    

            }
        );
    }

   
}



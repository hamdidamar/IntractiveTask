using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntractiveTask.Data.Seeders;

public static class DataSeeder
{
    public static void SeedMain(ModelBuilder modelBuilder)
    {
        UserSeeder.Seed(modelBuilder);
        ProjectSeeder.Seed(modelBuilder);
        ProjectTaskSeeder.Seed(modelBuilder);
    }

}

using IntractiveTask.Entity.Entities;
using IntractiveTask.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntractiveTask.Data.Seeders;

public class UserSeeder
{
    public static void SeedUser(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1, 
                Username = "admin",
                PasswordHash = HashPassword("admin123"),
                UserTypeId = (int)UserTypeEnum.Admin
            }
        );
    }

    private static string HashPassword(string password)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var bytes = System.Text.Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}

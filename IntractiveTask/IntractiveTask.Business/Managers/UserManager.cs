using IntractiveTask.Business.Managers.Base;
using IntractiveTask.Entity.Entities;
using IntractiveTask.Entity.Interfaces.Base;
using IntractiveTask.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntractiveTask.Business.Services;

namespace IntractiveTask.Business.Managers;

public class UserManager : BaseManager<User>, IUserManager
{
    private readonly IRepository<User> _repository;
    private readonly JwtService _jwtService;

    public UserManager(IRepository<User> repository, JwtService jwtService) : base(repository)
    {
        _repository = repository;
        _jwtService = jwtService;
    }

    public string Authenticate(string username, string password)
    {
        var user = _repository.Query().FirstOrDefault(u => u.Username == username);

        if (user == null || !VerifyPassword(password, user.PasswordHash))
        {
            throw new UnauthorizedAccessException("Wrong information");
        }

        var token = _jwtService.GenerateToken(user);
        return token;
    }

    public bool VerifyPassword(string password, string storedHash)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        var hashString = Convert.ToBase64String(hashBytes);

        return hashString == storedHash;
    }
}
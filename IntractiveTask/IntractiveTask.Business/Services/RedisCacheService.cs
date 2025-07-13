using IntractiveTask.Entity.Interfaces.Base;
using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IntractiveTask.Business.Services;

public class RedisCacheService : ICacheService
{
    private readonly StackExchange.Redis.IDatabase _database;

    public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
    {
        _database = connectionMultiplexer.GetDatabase();
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
    {
        string jsonData = JsonSerializer.Serialize(value);
        await _database.StringSetAsync(key, jsonData, expiration);
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        RedisValue redisValue = await _database.StringGetAsync(key);
        if (redisValue.IsNullOrEmpty)
            return default;

        try
        {
            return JsonSerializer.Deserialize<T>(redisValue.ToString());
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
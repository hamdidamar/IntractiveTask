using IntractiveTask.Entity.Interfaces.Base;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntractiveTask.Business.Managers.Base;

public class BaseManager<T> : IManager<T> where T : class
{
    private readonly IRepository<T> _repository;

    public BaseManager(IRepository<T> repository)
    {
        _repository = repository;
    }

    public Task CreateAsync(T entity)
    {
        return _repository.CreateAsync(entity);
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<T> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public IQueryable<T> Query(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = true)
    {
        return _repository.Query(predicate, include, enableTracking);
    }

    public Task RemoveAsync(T entity)
    {
        return _repository.RemoveAsync(entity);
    }

    public Task UpdateAsync(T entity)
    {
        return _repository.UpdateAsync(entity);
    }
}
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IntractiveTask.Entity.Interfaces.Base;

public interface IManager<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    IQueryable<T> Query(
       Expression<Func<T, bool>>? predicate = null,
       Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
       bool enableTracking = true
    );
}

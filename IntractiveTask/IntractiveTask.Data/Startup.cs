using IntractiveTask.Data.Repositories;
using IntractiveTask.Entity.Interfaces.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntractiveTask.Data;

public static class Startup
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddRepositories(configuration);
    }

    private static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
    }
}

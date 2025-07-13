using IntractiveTask.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntractiveTask.Entity.Helpers;

public static class CacheHelper
{
    public static TimeSpan GetCacheExpirationForModel(string modelName)
    {
        switch (modelName)
        {
            case "Project":
                return TimeSpan.FromMinutes((int)CacheTimeEnum.Long);
            case "ProjectTask":
                return TimeSpan.FromMinutes((int)CacheTimeEnum.Short);
            default:
                return TimeSpan.FromMinutes((int)CacheTimeEnum.Medium);
        }
    }

}

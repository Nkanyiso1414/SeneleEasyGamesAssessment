using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CacheManager.Core;
using System.Threading.Tasks;

namespace Senele.Solution.Configuration.CacheAdapter
{
    public static class MemCacheManagerAdapter
    {
        private static ICacheManager<object> SetupCache()
        {
            return CacheFactory.Build(settings => settings
               .WithUpdateMode(CacheUpdateMode.Up)
            );
        }
    }
}

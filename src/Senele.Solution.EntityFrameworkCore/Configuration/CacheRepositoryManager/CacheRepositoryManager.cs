using System;
using System.Collections.Generic;
using System.Linq;
using CacheManager.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Senele.Solution.Configuration.CacheRepositoryManager
{
    public class CacheRepositoryManager : DomainService
    {
        private readonly ICacheManager<object> _cache;
        public CacheRepositoryManager(ICacheManager<object> cache)
        {
            _cache = cache;
        }
        public T GetOrAddAsync<T>(string key, Func<T> builder, TimeSpan expirationTimeSpan)
        {
            var result = _cache.Get<T>(key);

            if (result != null)
            {
                return result;
            }
            result = builder();
            _cache.Add(key, result);
            _cache.Expire(key, ExpirationMode.Absolute, expirationTimeSpan);
            return result;
        }
    }
}

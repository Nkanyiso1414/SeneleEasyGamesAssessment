using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Senele.Solution.Data;
using Volo.Abp.DependencyInjection;

namespace Senele.Solution.EntityFrameworkCore;

public class EntityFrameworkCoreSolutionDbSchemaMigrator
    : ISolutionDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSolutionDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the SolutionDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SolutionDbContext>()
            .Database
            .MigrateAsync();
    }
}

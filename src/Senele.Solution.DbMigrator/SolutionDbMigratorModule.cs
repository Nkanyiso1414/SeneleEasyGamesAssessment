using Senele.Solution.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Senele.Solution.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SolutionEntityFrameworkCoreModule),
    typeof(SolutionApplicationContractsModule)
    )]
public class SolutionDbMigratorModule : AbpModule
{

}

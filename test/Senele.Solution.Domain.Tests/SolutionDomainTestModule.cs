using Senele.Solution.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Senele.Solution;

[DependsOn(
    typeof(SolutionEntityFrameworkCoreTestModule)
    )]
public class SolutionDomainTestModule : AbpModule
{

}

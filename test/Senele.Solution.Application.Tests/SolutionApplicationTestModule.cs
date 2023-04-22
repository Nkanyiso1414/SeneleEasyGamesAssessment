using Volo.Abp.Modularity;

namespace Senele.Solution;

[DependsOn(
    typeof(SolutionApplicationModule),
    typeof(SolutionDomainTestModule)
    )]
public class SolutionApplicationTestModule : AbpModule
{

}

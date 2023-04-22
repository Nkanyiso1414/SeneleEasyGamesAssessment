using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Senele.Solution.Web;

[Dependency(ReplaceServices = true)]
public class SolutionBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Solution";
}

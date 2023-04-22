using Senele.Solution.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Senele.Solution.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class SolutionPageModel : AbpPageModel
{
    protected SolutionPageModel()
    {
        LocalizationResourceType = typeof(SolutionResource);
    }
}

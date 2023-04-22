using System;
using System.Collections.Generic;
using System.Text;
using Senele.Solution.Localization;
using Volo.Abp.Application.Services;

namespace Senele.Solution;

/* Inherit your application services from this class.
 */
public abstract class SolutionAppService : ApplicationService
{
    protected SolutionAppService()
    {
        LocalizationResource = typeof(SolutionResource);
    }
}

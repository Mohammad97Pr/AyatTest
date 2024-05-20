using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AyatGroupTest.Controllers
{
    public abstract class AyatGroupTestControllerBase: AbpController
    {
        protected AyatGroupTestControllerBase()
        {
            LocalizationSourceName = AyatGroupTestConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

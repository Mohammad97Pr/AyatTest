using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AyatGroupTest.Configuration.Dto;

namespace AyatGroupTest.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AyatGroupTestAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

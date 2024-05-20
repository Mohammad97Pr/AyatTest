using System.Threading.Tasks;
using AyatGroupTest.Configuration.Dto;

namespace AyatGroupTest.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

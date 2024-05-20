using System.Threading.Tasks;
using Abp.Application.Services;
using AyatGroupTest.Sessions.Dto;

namespace AyatGroupTest.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

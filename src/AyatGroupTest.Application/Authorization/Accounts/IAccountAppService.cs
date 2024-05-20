using System.Threading.Tasks;
using Abp.Application.Services;
using AyatGroupTest.Authorization.Accounts.Dto;

namespace AyatGroupTest.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

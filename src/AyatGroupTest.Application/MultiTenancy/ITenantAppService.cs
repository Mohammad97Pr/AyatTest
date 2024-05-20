using Abp.Application.Services;
using AyatGroupTest.MultiTenancy.Dto;

namespace AyatGroupTest.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


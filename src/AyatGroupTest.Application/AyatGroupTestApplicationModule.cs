using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AyatGroupTest.Authorization;

namespace AyatGroupTest
{
    [DependsOn(
        typeof(AyatGroupTestCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AyatGroupTestApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AyatGroupTestAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AyatGroupTestApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}

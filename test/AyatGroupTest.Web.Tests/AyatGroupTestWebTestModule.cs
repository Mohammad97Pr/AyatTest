using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AyatGroupTest.EntityFrameworkCore;
using AyatGroupTest.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AyatGroupTest.Web.Tests
{
    [DependsOn(
        typeof(AyatGroupTestWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AyatGroupTestWebTestModule : AbpModule
    {
        public AyatGroupTestWebTestModule(AyatGroupTestEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AyatGroupTestWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AyatGroupTestWebMvcModule).Assembly);
        }
    }
}
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AyatGroupTest.Configuration;

namespace AyatGroupTest.Web.Host.Startup
{
    [DependsOn(
       typeof(AyatGroupTestWebCoreModule))]
    public class AyatGroupTestWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AyatGroupTestWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AyatGroupTestWebHostModule).GetAssembly());
        }
    }
}

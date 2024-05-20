using System.Threading.Tasks;
using AyatGroupTest.Models.TokenAuth;
using AyatGroupTest.Web.Controllers;
using Shouldly;
using Xunit;

namespace AyatGroupTest.Web.Tests.Controllers
{
    public class HomeController_Tests: AyatGroupTestWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
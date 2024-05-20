using System;
using System.IO;
using System.Threading.Tasks;
using Abp;
using Abp.Configuration;
using Abp.UI;
using Abp.Zero.Configuration;
using AyatGroupTest.Authorization.Accounts.Dto;
using AyatGroupTest.Authorization.Users;
using AyatGroupTest.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace AyatGroupTest.Authorization.Accounts
{
    public class AccountAppService : AyatGroupTestAppServiceBase, IAccountAppService
    {
        // from: http://regexlib.com/REDetails.aspx?regexp_id=1923
        public const string PasswordRegex = "(?=^.{8,}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\\s)[0-9a-zA-Z!@#$%^&*()]*$";

        private readonly UserRegistrationManager _userRegistrationManager;
        public AccountAppService(
            UserRegistrationManager userRegistrationManager)
        {
            _userRegistrationManager = userRegistrationManager;
        }



        public async Task<RegisterOutput> Register(RegisterInput input)
        {
            var user = await _userRegistrationManager.RegisterAsync(
                input.Name,
                input.Surname,
                input.EmailAddress,
                input.UserName,
                input.Password,
                                true // Assumed email address is always confirmed. Change this if you want to implement email confirmation.
            );
            if (!string.IsNullOrEmpty(input.ImageProfile))
                user.ProfilePhoto = input.ImageProfile;

            var isEmailConfirmationRequiredForLogin = await SettingManager.GetSettingValueAsync<bool>(AbpZeroSettingNames.UserManagement.IsEmailConfirmationRequiredForLogin);

            return new RegisterOutput
            {
                CanLogin = user.IsActive && (user.IsEmailConfirmed || !isEmailConfirmationRequiredForLogin)
            };
        }

    }
}

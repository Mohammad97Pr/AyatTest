using Abp.Authorization;
using AyatGroupTest.Authorization.Roles;
using AyatGroupTest.Authorization.Users;

namespace AyatGroupTest.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

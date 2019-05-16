using Hilton.HotelManagement.Localization.HotelManagement;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hilton.HotelManagement.Permissions
{
    public class HotelManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(HotelManagementPermissions.GroupName);

            //Define your own permissions here. Examaple:
            //myGroup.AddPermission(HotelManagementPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HotelManagementResource>(name);
        }
    }
}

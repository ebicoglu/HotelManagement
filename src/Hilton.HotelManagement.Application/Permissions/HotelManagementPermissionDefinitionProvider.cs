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

            //myGroup.AddPermission(HotelManagementPermissions.Pages_Reservations_Get, L("Permission:Get"));
            //myGroup.AddPermission(HotelManagementPermissions.Pages_Reservations_Create, L("Permission:Create"));
            //myGroup.AddPermission(HotelManagementPermissions.Pages_Reservations_Update, L("Permission:Update"));
            //myGroup.AddPermission(HotelManagementPermissions.Pages_Reservations_Delete, L("Permission:Delete"));

            myGroup.AddPermission(HotelManagementPermissions.Pages_Reservations_Get, L("Permission:Get"));
            myGroup.AddPermission(HotelManagementPermissions.Pages_Reservations_Create, L("Permission:Create"));
            myGroup.AddPermission(HotelManagementPermissions.Pages_Reservations_Update, L("Permission:Update"));
            myGroup.AddPermission(HotelManagementPermissions.Pages_Reservations_Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HotelManagementResource>(name);
        }
    }
}
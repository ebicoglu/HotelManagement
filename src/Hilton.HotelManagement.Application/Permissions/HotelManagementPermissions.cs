using Volo.Abp.Reflection;

namespace Hilton.HotelManagement.Permissions
{
    public static class HotelManagementPermissions
    {
        public const string GroupName = "HotelManagement";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
        public const string Pages_Reservations_Get = GroupName + "Pages.Reservations.Get";
        public const string Pages_Reservations_Create = GroupName + "Pages.Reservations.Create";
        public const string Pages_Reservations_Update = GroupName + "Pages.Reservations.Edit";
        public const string Pages_Reservations_Delete = GroupName + "Pages.Reservations.Delete";

        public static string[] GetAll()
        {
            //Return an array of all permissions
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(HotelManagementPermissions));
        }
    }
}
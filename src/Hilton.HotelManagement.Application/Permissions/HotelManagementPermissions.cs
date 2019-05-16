using System;
using Volo.Abp.Reflection;

namespace Hilton.HotelManagement.Permissions
{
    public static class HotelManagementPermissions
    {
        public const string GroupName = "HotelManagement";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public static string[] GetAll()
        {
            //Return an array of all permissions
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(HotelManagementPermissions));
        }
    }
}
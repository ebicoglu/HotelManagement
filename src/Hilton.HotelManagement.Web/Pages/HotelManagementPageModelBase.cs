using Hilton.HotelManagement.Localization.HotelManagement;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hilton.HotelManagement.Pages
{
    public abstract class HotelManagementPageModelBase : AbpPageModel
    {
        protected HotelManagementPageModelBase()
        {
            LocalizationResourceType = typeof(HotelManagementResource);
        }
    }
}
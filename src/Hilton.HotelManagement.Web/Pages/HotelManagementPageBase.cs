using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Hilton.HotelManagement.Localization.HotelManagement;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Hilton.HotelManagement.Pages
{
    public abstract class HotelManagementPageBase : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<HotelManagementResource> L { get; set; }
    }
}

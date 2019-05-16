using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Hilton.HotelManagement.Branding
{
    [Dependency(ReplaceServices = true)]
    public class HotelManagementBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "HotelManagement";
    }
}

using Volo.Abp.Settings;

namespace Hilton.HotelManagement.Settings
{
    public class HotelManagementSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(HotelManagementSettings.MySetting1));
        }
    }
}

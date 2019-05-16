using Volo.Abp;

namespace Hilton.HotelManagement
{
    public abstract class HotelManagementApplicationTestBase : AbpIntegratedTest<HotelManagementApplicationTestModule>
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}

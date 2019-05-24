using System.Threading.Tasks;
using Hilton.HotelManagement.AppServices.HotelOperations.Reservations.Dtos;
using Volo.Abp.Application.Dtos;

namespace Hilton.HotelManagement.AppServices.HotelOperations.Reservations
{
    public interface IReservationAppService
    {
        Task<PagedResultDto<ReservationDto>> GetListAsync(GetReservationsInput input);

        Task<ReservationDto> GetAsync(long id);

        Task DeleteAsync(long id);

        Task<ReservationDto> CreateAsync(ReservationCreateDto input);

        Task UpdateAsync(ReservationUpdateDto input);
    }
}
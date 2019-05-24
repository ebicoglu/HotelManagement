using Hilton.HotelManagement.HotelOperations;
using Volo.Abp.Application.Dtos;

namespace Hilton.HotelManagement.AppServices.HotelOperations.Reservations.Dtos
{
    public class GetReservationsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public ReservationQueryFilter ReservationFilter { get; set; }

        public GetReservationsInput()
        {
            ReservationFilter = new ReservationQueryFilter();
        }
    }
}
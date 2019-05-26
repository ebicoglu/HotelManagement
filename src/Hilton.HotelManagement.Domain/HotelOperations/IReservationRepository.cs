using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hilton.HotelManagement.HotelOperations
{
    public interface IReservationRepository : IRepository<Reservation, long>
    {
        Task<List<Reservation>> GetListAsync(
            string filterText = null,
            ReservationQueryFilter reservationQueryFilter = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(string filterText = null,
            ReservationQueryFilter reservationQueryFilter = null,
            CancellationToken cancellationToken = default);
    }
}
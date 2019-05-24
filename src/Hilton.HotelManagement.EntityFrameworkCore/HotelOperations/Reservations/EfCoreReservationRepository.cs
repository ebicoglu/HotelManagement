using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Hilton.HotelManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hilton.HotelManagement.HotelOperations.Reservations
{
    public class EfCoreReservationRepository : EfCoreRepository<HotelManagementDbContext, Reservation, long>, IReservationRepository
    {
        public EfCoreReservationRepository(IDbContextProvider<HotelManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Reservation>> GetListAsync(string filterText = null,
            ReservationQueryFilter reservationQueryFilter = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, reservationQueryFilter);

            if (string.IsNullOrWhiteSpace(sorting))
            {
                query = query.OrderBy(Reservation.DefaultSorting);
            }

            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(string filterText = null,
            ReservationQueryFilter reservationQueryFilter = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, reservationQueryFilter);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Reservation> ApplyFilter(IQueryable<Reservation> query, string filter, ReservationQueryFilter queryFilter)
        {
            query = query.WhereIf(!filter.IsNullOrWhiteSpace(),
                      e => e.NameSurname.Contains(filter, StringComparison.OrdinalIgnoreCase)); //todo: search on all string fields

            if (queryFilter != null)
            {
                query = query
                    .WhereIf(!string.IsNullOrWhiteSpace(queryFilter.NameSurname), e => e.NameSurname.Contains(queryFilter.NameSurname, StringComparison.OrdinalIgnoreCase))
                    
                    .WhereIf(queryFilter.CheckinDateMin.HasValue, e => e.CheckinDate >= queryFilter.CheckinDateMin.Value)
                    .WhereIf(queryFilter.CheckinDateMax.HasValue, e => e.CheckinDate <= queryFilter.CheckinDateMax.Value)
                    
                    .WhereIf(queryFilter.IsPaid.HasValue, e => e.IsPaid == queryFilter.IsPaid)

                    .WhereIf(queryFilter.PersonCountMin.HasValue, e => e.PersonCount >= queryFilter.PersonCountMin.Value)
                    .WhereIf(queryFilter.PersonCountMax.HasValue, e => e.PersonCount <= queryFilter.PersonCountMax.Value)

                    .WhereIf(queryFilter.PriceMin.HasValue, e => e.Price >= queryFilter.PriceMin.Value)
                    .WhereIf(queryFilter.PriceMax.HasValue, e => e.Price <= queryFilter.PriceMax.Value);

                //todo: add other properties for filterText
            }

            return query;
        }
    }
}
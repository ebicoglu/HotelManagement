using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hilton.HotelManagement.EntityFrameworkCore;

namespace Hilton.HotelManagement.Students
{
    public class EfCoreStudentRepository : EfCoreRepository<HotelManagementDbContext, Student, int>, IStudentRepository
    {
        public EfCoreStudentRepository(IDbContextProvider<HotelManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Student>> GetListAsync(string filterText = null,
            StudentQueryFilter studentQueryFilter = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, studentQueryFilter);

            if (string.IsNullOrWhiteSpace(sorting))
            {
                query = query.OrderBy(Student.DefaultSorting);
            }

            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(string filterText = null,
            StudentQueryFilter studentQueryFilter = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(DbSet, filterText, studentQueryFilter);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Student> ApplyFilter(IQueryable<Student> query, string filter, StudentQueryFilter queryFilter)
        {
            query = query.WhereIf(!filter.IsNullOrWhiteSpace(), e =>
                    e.NameSurname.Contains(filter, StringComparison.OrdinalIgnoreCase));

            if (queryFilter != null)
            {
                query = query

                    .WhereIf(queryFilter.CheckinDateMin.HasValue, e => e.CheckinDate >= queryFilter.CheckinDateMin.Value)
                    .WhereIf(queryFilter.CheckinDateMax.HasValue, e => e.CheckinDate <= queryFilter.CheckinDateMax.Value)

                    .WhereIf(queryFilter.PersonCountMin.HasValue, e => e.PersonCount >= queryFilter.PersonCountMin.Value)
                    .WhereIf(queryFilter.PersonCountMax.HasValue, e => e.PersonCount <= queryFilter.PersonCountMax.Value)

                    .WhereIf(queryFilter.IsPaid.HasValue, e => e.IsPaid == queryFilter.IsPaid)

                    .WhereIf(!string.IsNullOrWhiteSpace(queryFilter.NameSurname), e => e.NameSurname.Contains(queryFilter.NameSurname, StringComparison.OrdinalIgnoreCase))

                    .WhereIf(queryFilter.PriceMin.HasValue, e => e.Price >= queryFilter.PriceMin.Value)
                    .WhereIf(queryFilter.PriceMax.HasValue, e => e.Price <= queryFilter.PriceMax.Value);
            }

            return query;
        }
    }
}
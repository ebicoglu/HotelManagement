using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hilton.HotelManagement.Students
{
    public interface IStudentRepository : IRepository<Student, int>
    {
        Task<List<Student>> GetListAsync(
            string filterText = null,
            StudentQueryFilter studentQueryFilter = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(string filterText = null,
            StudentQueryFilter studentQueryFilter = null,
            CancellationToken cancellationToken = default);
    }
}
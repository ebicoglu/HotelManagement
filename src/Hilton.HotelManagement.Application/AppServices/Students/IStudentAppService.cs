using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Hilton.HotelManagement.AppServices.Students.Dtos;

namespace Hilton.HotelManagement.AppServices.Students
{
    public interface IStudentAppService
    {
        Task<PagedResultDto<StudentDto>> GetListAsync(GetStudentsInput input);

        Task<StudentDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<StudentDto> CreateAsync(StudentCreateDto input);

        Task UpdateAsync(StudentUpdateDto input);
    }
}
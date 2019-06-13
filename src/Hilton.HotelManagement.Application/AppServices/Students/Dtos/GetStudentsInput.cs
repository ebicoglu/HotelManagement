using Hilton.HotelManagement.Students;
using Volo.Abp.Application.Dtos;

namespace Hilton.HotelManagement.AppServices.Students.Dtos
{
    public class GetStudentsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public StudentQueryFilter StudentFilter { get; set; }

        public GetStudentsInput()
        {
            StudentFilter = new StudentQueryFilter();
        }
    }
}
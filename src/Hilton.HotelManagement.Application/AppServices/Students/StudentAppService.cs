using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hilton.HotelManagement.Permissions;
using Hilton.HotelManagement.Students;
using Hilton.HotelManagement.AppServices.Students.Dtos;

namespace Hilton.HotelManagement.AppServices.Students
{
    [Authorize(HotelManagementPermissions.Pages_Students_Get)]
    public class StudentAppService : ApplicationService, IStudentAppService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentAppService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public virtual async Task<PagedResultDto<StudentDto>> GetListAsync(GetStudentsInput input)
        {
            var totalCount = await _studentRepository.GetCountAsync(input.FilterText, input.StudentFilter);

            var items = await _studentRepository
                .GetListAsync(
                    input.FilterText,
                    input.StudentFilter,
                    input.Sorting,
                    input.MaxResultCount,
                    input.SkipCount
                );

            return new PagedResultDto<StudentDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Student>, List<StudentDto>>(items)
            };
        }

        public virtual async Task<StudentDto> GetAsync(int id)
        {
            return ObjectMapper.Map<Student, StudentDto>(
                await _studentRepository.GetAsync(id));
        }

        [Authorize(HotelManagementPermissions.Pages_Students_Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _studentRepository.DeleteAsync(id);
        }

        [Authorize(HotelManagementPermissions.Pages_Students_Create)]
        public virtual async Task<StudentDto> CreateAsync(StudentCreateDto input)
        {
            var newStudent = ObjectMapper.Map<StudentCreateDto, Student>(input);


            newStudent.TenantId = CurrentTenant.Id;


            var student = await _studentRepository.InsertAsync(newStudent);

            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<Student, StudentDto>(student);
        }

        [Authorize(HotelManagementPermissions.Pages_Students_Update)]
        public virtual async Task UpdateAsync(StudentUpdateDto input)
        {
            var student = await _studentRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, student);
        }
    }
}
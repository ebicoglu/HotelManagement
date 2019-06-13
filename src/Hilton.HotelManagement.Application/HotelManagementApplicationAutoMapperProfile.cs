using Hilton.HotelManagement.AppServices.Students.Dtos;
using Hilton.HotelManagement.Students;
using AutoMapper;
using Hilton.HotelManagement.AppServices.HotelOperations.Reservations.Dtos;
using Hilton.HotelManagement.HotelOperations;

namespace Hilton.HotelManagement
{
    public class HotelManagementApplicationAutoMapperProfile : Profile
    {
        public HotelManagementApplicationAutoMapperProfile()
        {
            //Configure your AutoMapper mapping configuration here...
            CreateMap<ReservationCreateDto, Reservation>();
            CreateMap<Reservation, ReservationDto>();
            CreateMap<ReservationUpdateDto, Reservation>();

            CreateMap<StudentCreateDto, Student>();
            CreateMap<Student, StudentDto>();
            CreateMap<StudentUpdateDto, Student>();
        }
    }
}
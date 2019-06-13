using System;
using Volo.Abp.Application.Dtos;

namespace Hilton.HotelManagement.AppServices.Students.Dtos
{
    public class StudentDto : IEntityDto<int> //todo: which interface?
    {
        public int Id { get; set; }

        public DateTime CheckinDate { get; set; }
        public byte PersonCount { get; set; }
        public bool IsPaid { get; set; }
        public string NameSurname { get; set; }
        public double Price { get; set; }

    }
}
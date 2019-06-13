using System;

namespace Hilton.HotelManagement.AppServices.Students.Dtos
{
    public class StudentCreateDto
    {
        public DateTime CheckinDate { get; set; }
        public byte PersonCount { get; set; }
        public bool IsPaid { get; set; }
        public string NameSurname { get; set; }
        public double Price { get; set; }

    }
}
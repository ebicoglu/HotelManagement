using System;
using Volo.Abp.Application.Dtos;

namespace Hilton.HotelManagement.AppServices.HotelOperations.Reservations.Dtos
{
    public class ReservationDto : IEntityDto<long> //todo: which interface?
    {
        public long Id { get; set; }

        public DateTime CheckinDate { get; set; }
        public byte PersonCount { get; set; }
        public bool IsPaid { get; set; }
        public string NameSurname { get; set; }
        public double Price { get; set; }

    }
}
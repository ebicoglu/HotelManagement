using System;
using Volo.Abp.Application.Dtos;

namespace Hilton.HotelManagement.AppServices
{
    public class ReservationDto : IEntityDto<long>
    {
        public long Id { get; set; }

        public virtual DateTime CheckinDate { get; set; }

        public virtual byte PersonCount { get; set; }

        public virtual bool IsPaid { get; set; }

        public virtual string NameSurname { get; set; }

        public virtual double Price { get; set; }

        public virtual Guid? TenantId { get; set; }
    }
}
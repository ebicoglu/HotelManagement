using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Hilton.HotelManagement.HotelOperations
{
    public class Reservation : IEntity<long>, IMultiTenant
    {
        public virtual DateTime CheckinDate { get; protected set; }
        public virtual byte PersonCount { get; protected set; }
        public virtual bool IsPaid { get; protected set; }
        public virtual string NameSurname { get; protected set; }
        public virtual double Price { get; protected set; }
        public virtual Guid? TenantId { get; protected set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }

        public long Id { get; set; }
    }
}
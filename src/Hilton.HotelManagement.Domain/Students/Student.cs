using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Hilton.HotelManagement.Students
{
    public class Student : Entity<int>, IMultiTenant
    {
        public const string DefaultSorting = "CheckinDate desc,NameSurname asc";

        public virtual DateTime CheckinDate { get; set; }
        public virtual byte PersonCount { get; set; }
        public virtual bool IsPaid { get; set; }
        public virtual string NameSurname { get; set; }
        public virtual double Price { get; set; }
        public virtual Guid? TenantId { get; set; }

    }
}
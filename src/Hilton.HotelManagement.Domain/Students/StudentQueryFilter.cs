using System;

namespace Hilton.HotelManagement.Students
{
    public class StudentQueryFilter
    {
        public virtual DateTime? CheckinDateMin { get; set; }
        public virtual DateTime? CheckinDateMax { get; set; }

        public virtual byte? PersonCountMin { get; set; }
        public virtual byte? PersonCountMax { get; set; }

        public virtual bool? IsPaid { get; set; }

        public virtual string NameSurname { get; set; }

        public virtual double? PriceMin { get; set; }
        public virtual double? PriceMax { get; set; }
    }
}
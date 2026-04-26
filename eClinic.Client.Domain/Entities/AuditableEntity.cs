using System;
using System.Collections.Generic;
using System.Text;

namespace eClinic.Client.Domain.Entities
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
    }
}

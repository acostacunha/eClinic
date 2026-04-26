using System;
using System.Collections.Generic;
using System.Text;

namespace eClinic.Client.Domain.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public Guid PublicId { get; set; }
    }
}

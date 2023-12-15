using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Domain.Common
{
    public abstract class AuditableWithBaseEntity<T> : BaseEntity<T>, IAuditableEntity
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime Created { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public long UpdatedBy { get; set; }
    }
}

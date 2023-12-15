using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Common;

namespace University.Domain.Entities
{
    public class Course : AuditableWithBaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public int? LecurerId { get; set; } 
        public Lecturer? Lecturer { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Common;

namespace University.Domain.Entities
{
    public class StudentCourse : AuditableWithBaseEntity<int>
    {
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
        public int? StudentId { get; set; }
        public Student? Student { get; set; }
    }
}

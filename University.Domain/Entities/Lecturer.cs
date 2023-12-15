using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Common;

namespace University.Domain.Entities
{
    public class Lecturer : AuditableWithBaseEntity<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName  => FirstName + " " + LastName;
        public DateTime DateOfBirth { get; set; }
        public int Age => CalculateAge(DateOfBirth);

        //calculate Age
        public int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age))
            {
                return age;
            }
            else
            {
                return age;
            }
        }
    }
}

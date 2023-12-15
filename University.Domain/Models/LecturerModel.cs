using Microsoft.AspNetCore.Http;
namespace University.Domain.Models
{
    public class LecturerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

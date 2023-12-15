using Microsoft.AspNetCore.Http;
namespace University.Domain.Models
{
    public class AssignLecturerModel
    {
        public int Id { get; set; }
        public int LecturerId { get; set; }
    }
}

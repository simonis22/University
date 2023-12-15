using Microsoft.AspNetCore.Http;
namespace University.Domain.Models
{
    public class LecturerCourseModel
    {
        public int LecurerId { get; set; }
        public int CourseId { get; set; }
    }
}

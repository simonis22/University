using University.Domain.Entities;

namespace University.Application.Common.Users
{
    public interface IUniversityServices
    {
        Task<List<Student>> GetStudentsAsync(string? name);
        Task<List<Lecturer>> GetLecturersAsync(string? name);

        Task<Student> UpsertAsync(Student user);
        Task<Course> UpsertAsync(Course course);
        Task<Lecturer> UpsertAsync(Lecturer lecturer);
        Task<StudentCourse> EnrollStudentAsync(StudentCourse studentCourse);
        Task<Course> AssignLecturerAsync(Course lecturerCourse);
        Task<List<StudentCourse>> GetStudentsForLecturerAsync(int id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> DeleteCourseAsync(int Id);

    }
}

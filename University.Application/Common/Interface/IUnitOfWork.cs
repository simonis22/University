using University.Domain.Entities;

namespace University.Application.Common.Interface
{
    public interface IUnitOfWork
    {
        IRepository<Student> StudentRepo { get; }
        IRepository<Course> CourseRepo { get; }
        IRepository<Lecturer> LecturerRepo { get; }
        IRepository<StudentCourse> StudentCourseRepo { get; }


        Task<int> SaveAsync();
        int Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}

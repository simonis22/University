using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using University.Application.Common.Interface;
using University.Domain.Entities;

namespace University.Application.Common.Users
{
    public class UniversityServices : IUniversityServices
    {
        #region Properties
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Ctor
        public UniversityServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Command
        public async Task<Student> UpsertAsync(Student user)
        {
            try
            {
                if (user.Id > 0)
                    _unitOfWork.StudentRepo.Update(user);
                else
                    _unitOfWork.StudentRepo.Add(user);

                await _unitOfWork.SaveAsync();
                return user;
            }
            catch (Exception)
            {
                //Handle Exception
                throw;
            }

        }
        public async Task<Course> UpsertAsync(Course course)
        {
            try
            {
                if (course.Id > 0)
                    _unitOfWork.CourseRepo.Update(course);
                else
                    _unitOfWork.CourseRepo.Add(course);

                await _unitOfWork.SaveAsync();
                return course;
            }
            catch (Exception)
            {
                //Handle Exception
                throw;
            }
        }
        public async Task<Lecturer> UpsertAsync(Lecturer lecturer)
        {
            try
            {
                if (lecturer.Id > 0)
                    _unitOfWork.LecturerRepo.Update(lecturer);
                else
                    _unitOfWork.LecturerRepo.Add(lecturer);

                await _unitOfWork.SaveAsync();
                return lecturer;
            }
            catch (Exception)
            {
                //Handle Exception
                throw;
            }
        }
        public async Task<StudentCourse> EnrollStudentAsync(StudentCourse studentCourse)
        {
            try
            {
                if (studentCourse.Id > 0)
                    _unitOfWork.StudentCourseRepo.Update(studentCourse);
                else
                    _unitOfWork.StudentCourseRepo.Add(studentCourse);

                await _unitOfWork.SaveAsync();
                return studentCourse;
            }
            catch (Exception)
            {
                //Handle Exception
                throw;
            }
        }
        public async Task<Course> AssignLecturerAsync(Course lecturerCourse)
        {
            try
            {
                if (lecturerCourse.Id > 0)
                    _unitOfWork.CourseRepo.Update(lecturerCourse);
                else
                    _unitOfWork.CourseRepo.Add(lecturerCourse);

                await _unitOfWork.SaveAsync();
                return lecturerCourse;
            }
            catch (Exception)
            {
                //Handle Exception
                throw;
            }
        }
        public async Task<bool> DeleteAsync(int Id)
        {
            try
            {
                var IsDeteted = await _unitOfWork.StudentRepo.Delete(Id);
                var studentCourses = _unitOfWork.StudentCourseRepo
                .TableNoTracking
                .Where(t => t.StudentId == Id)
                .ToList();
                foreach (var studentCourse in studentCourses)
                {
                    studentCourse.IsDeleted = true;
                    await EnrollStudentAsync(studentCourse);
                }
                await _unitOfWork.SaveAsync();
                return IsDeteted;
            }
            catch (Exception)
            {
                //handle exception
                return false;
            }
        }
        public async Task<bool> DeleteCourseAsync(int Id)
        {
            try
            {
                var IsDeteted = await _unitOfWork.CourseRepo.Delete(Id);
                var studentCourses = _unitOfWork.StudentCourseRepo
                .TableNoTracking
                .Where(t => t.CourseId == Id)
                .ToList();
                foreach (var studentCourse in studentCourses)
                {
                    studentCourse.IsDeleted = true;
                    await EnrollStudentAsync(studentCourse);
                }
                await _unitOfWork.SaveAsync();
                return IsDeteted;
            }
            catch (Exception)
            {
                //handle exception
                return false;
            }
        }
        #endregion
        #region Queries
        public async Task<List<Student>> GetStudentsAsync(string? name)
        {
            if (name == null)
            {
                var students = await _unitOfWork.StudentRepo
                .TableNoTracking
                .ToListAsync();
                return students;
            }
            else
            {
                var students = await _unitOfWork.StudentRepo
                .TableNoTracking
                .Where(t => t.FirstName == name || t.LastName == name)
                .ToListAsync();
                return students;
            }
        }
        public async Task<List<Lecturer>> GetLecturersAsync(string? name)
        {
            if (name == null)
            {
                var lecturers = await _unitOfWork.LecturerRepo
                .TableNoTracking
                .ToListAsync();
                return lecturers;
            }
            else
            {
                var lecturers = await _unitOfWork.LecturerRepo
                .TableNoTracking
                .Where(t => t.FirstName == name || t.LastName == name)
                .ToListAsync();
                return lecturers;
            }
        }
        public async Task<List<StudentCourse>> GetStudentsForLecturerAsync(int id)
        {
            var students = await _unitOfWork.StudentCourseRepo
            .TableNoTracking
            .Include(x=>x.Course)
            .Include(x=>x.Student)
            .Where(t => t.Course.LecurerId == id)
            .ToListAsync();
            return students;
        }
        #endregion
    }
}

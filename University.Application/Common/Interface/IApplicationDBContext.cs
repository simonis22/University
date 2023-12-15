using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Entities;

namespace University.Application.Common.Interface
{
    public interface IApplicationDBContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Lecturer> Lecturers { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<StudentCourse> StudentCourses { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}

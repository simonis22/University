using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using University.Application.Common.Interface;
using University.Domain.Common;
using University.Domain.Entities;

namespace University.Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext, IApplicationDBContext
    {
        #region Properties
        private readonly DateTime _currentDateTime;
        #endregion

        #region Ctor
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
          : base(options)
        {
            _currentDateTime = DateTime.Now;
        }
        #endregion

        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }



        public Task<int> SaveChangesAsync()
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = 1; //Get Current UsereID
                        entry.Entity.Created = _currentDateTime;
                        entry.Entity.UpdatedBy = 1; //Get Current UsereID
                        entry.Entity.Updated = _currentDateTime;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = 1; //Get Current UsereID
                        entry.Entity.Updated = _currentDateTime;
                        break;
                }
            }
            return base.SaveChangesAsync();
        }

        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
        }
    }
}

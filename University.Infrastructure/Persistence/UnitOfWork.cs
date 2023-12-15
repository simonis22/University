using Microsoft.EntityFrameworkCore.Storage;
using University.Application.Common.Interface;
using University.Domain.Entities;

namespace University.Infrastructure.Persistence
{
    internal class UnitOfWork : IUnitOfWork
    {
        #region Properties
        private readonly ApplicationDBContext _context;
        IDbContextTransaction dbContextTransaction;
        private IRepository<Student> _studentRepo;
        private IRepository<Course> _courseRepo;
        private IRepository<Lecturer> _lecturerRepo;
        private IRepository<StudentCourse> _studentCourseRepo;



        #endregion
        #region Ctor
        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }
        #endregion

        #region Repository/*
        public IRepository<Student> StudentRepo
        {
            get
            {
                if (this._studentRepo == null)
                    this._studentRepo = new EfRepository<Student>(_context);
                return _studentRepo;
            }
        }
        public IRepository<Course> CourseRepo
        {
            get
            {
                if (this._courseRepo == null)
                    this._courseRepo = new EfRepository<Course>(_context);
                return _courseRepo;
            }
        }
        public IRepository<Lecturer> LecturerRepo
        {
            get
            {
                if (this._lecturerRepo == null)
                    this._lecturerRepo = new EfRepository<Lecturer>(_context);
                return _lecturerRepo;
            }
        }
        public IRepository<StudentCourse> StudentCourseRepo
        {
            get
            {
                if (this._studentCourseRepo == null)
                    this._studentCourseRepo = new EfRepository<StudentCourse>(_context);
                return _studentCourseRepo;
            }
        }
        #endregion
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void BeginTransaction()
        {
            dbContextTransaction = _context.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Commit();
            }
        }
        public void RollbackTransaction()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Rollback();
            }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

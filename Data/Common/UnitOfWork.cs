using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Data.UnitOfWork;
using StudentsCoursesManager.Repository;

namespace StudentsCoursesManager.Data.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        public IRepository<Student, int> StudentRepository { get; set; }
        public IRepository<Course, int> CourseRepository { get; set; }
        public IRepository<StudentCourse, int> StudentCourseRepository { get; set; }
        public IRepository<Gender, int> GenderRepository { get; set; }


        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;

            StudentRepository = new EfRepository<Student, int>(_dataContext);
            StudentCourseRepository = new EfRepository<StudentCourse, int>(_dataContext);
            CourseRepository = new EfRepository<Course, int>(_dataContext);
            GenderRepository = new EfRepository<Gender, int>(_dataContext);
        }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}

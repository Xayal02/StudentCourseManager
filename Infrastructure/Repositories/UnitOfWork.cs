using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        public IRepository<Student, int> StudentRepository { get; set; }
        public IRepository<Course, int> CourseRepository { get; set; }
        public IRepository<StudentCourse, int> StudentCourseRepository { get; set; }
        public IRepository<Gender, int> GenderRepository { get; set; }
        public IRepository<User, int> UserRepository { get; set; }


        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;

            StudentRepository = new EfRepository<Student, int>(_dataContext);
            StudentCourseRepository = new EfRepository<StudentCourse, int>(_dataContext);
            CourseRepository = new EfRepository<Course, int>(_dataContext);
            GenderRepository = new EfRepository<Gender, int>(_dataContext);
            UserRepository = new EfRepository<User, int>(_dataContext);
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

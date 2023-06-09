﻿using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Infrastructure.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Student, int> StudentRepository { get; set; }
        public IRepository<Course, int> CourseRepository { get; set; }
        public IRepository<StudentCourse, int> StudentCourseRepository { get; set; }
        public IRepository<Gender, int> GenderRepository { get; set; }
        public IRepository<User, int> UserRepository { get; set; }

        public Task Save();
    }
}

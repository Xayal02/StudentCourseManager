using AutoMapper;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Data.Entities;

namespace StudentsCoursesManager.Application.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentModel>();
            CreateMap<StudentModel, Student>();

            CreateMap<Course, CourseModel>();
            CreateMap<CourseModel, Course>();

            CreateMap<StudentCourse, StudentCourseModel>();
            CreateMap<StudentCourseModel, StudentCourse>();

            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();

        }
    }
}

﻿using AutoMapper;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Helpers
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

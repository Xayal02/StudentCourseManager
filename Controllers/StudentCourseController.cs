using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentsCoursesManager.Data.Common;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Data.UnitOfWork;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<StudentCourseModel> _validator;
        private readonly DataContext _dataContext;

        public StudentCourseController(IUnitOfWork unitOfWork, IMapper mapper, IValidator<StudentCourseModel> validator, DataContext dataContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
            _dataContext = dataContext;
        }
        [HttpGet("Get Current Student")]
        public async Task<IActionResult> GetCourses()
        {
            var studentCourses2 =  _unitOfWork.StudentCourseRepository.GetAll();

            var studentCourses4 = await  studentCourses2.Select(sc => new
            {
                StartDate = sc.StartDate,
                EndDate = sc.EndDate,
                StudentFullName= (sc.Student.FirstName + " " + sc.Student.LastName),
                Courses = new
                {
                    CourseName = sc.Course.Name
                }
            }).ToListAsync();


            

          //  var studentCourses2 = studentCourses1.Where(x => x.StudentCourses is not null).ToList();
            



            return Ok(studentCourses4); 
        }

        //[HttpGet("Get Course By Id")]
        //public async Task<IActionResult> GetCourseById(int id, CancellationToken cancellationToken)
        //{
        //}

        //[HttpPost("Create Course")]
        //public async Task<IActionResult> CreateCourse([FromBody] CourseModel courseModel, [FromServices] IOptions<ApiBehaviorOptions> apiBehaviour)
        //{

        //}

        //[HttpPut("Update Course")]
        //public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseModel courseModel, [FromServices] IOptions<ApiBehaviorOptions> apiBehaviour)
        //{

        //}

        //[HttpDelete("Delete Course")]
        //public async Task<IActionResult> DeleteStudent(int id)
        //{

        //}
    }
    
}

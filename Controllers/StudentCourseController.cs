using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentsCoursesManager.Data.Common;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Data.UnitOfWork;
using StudentsCoursesManager.Data.Validators;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Controllers
{
    [Authorize(Policy = "AuthenticatedUser")]
    public class StudentCourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<StudentCourseModel> _validator;

        public StudentCourseController(IUnitOfWork unitOfWork, IMapper mapper, IValidator<StudentCourseModel> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }
        [HttpGet("Get Current Courses")]
        public async Task<IActionResult> GetCourses()
        {
            var allCourses =  _unitOfWork.StudentCourseRepository.GetAll();

            var studentCourses4 =  await allCourses.Select(sc => new
            {
                StartDate = sc.StartDate,
                EndDate = sc.EndDate,
                StudentFullName = (sc.Student.FirstName + " " + sc.Student.LastName),
                Courses = new
                {
                    CourseName = sc.Course.Name
                }
            }).ToListAsync();

            return Ok(studentCourses4); 
        }

        [HttpGet("Get Course By Student Id")]
        public async Task<IActionResult> GetCourseByStudentId(int studentId, CancellationToken cancellationToken)
        {
            var allcourses = _unitOfWork.StudentCourseRepository.GetAll();

            var studentCourses = await allcourses
                .Where(sc => sc.StudentId == studentId)
                .Select(sc => new
                {
                    StartDate = sc.StartDate,
                    EndDate = sc.EndDate,
                    StudentFullName = (sc.Student.FirstName + " " + sc.Student.LastName),
                    Courses = sc.Course.Name
                }).ToListAsync();

            return Ok(studentCourses);
        }

        [HttpGet("Get Course By Course Id")]
        public async Task<IActionResult> GetCourseByCourseId(int courseId, CancellationToken cancellationToken)
        {
            var allcourses = _unitOfWork.StudentCourseRepository.GetAll();

            var studentCourses = await allcourses
                .Where(sc => sc.CourseId == courseId)
                .Select(sc => new
                {
                    StartDate = sc.StartDate,
                    EndDate = sc.EndDate,
                    StudentFullName = (sc.Student.FirstName + " " + sc.Student.LastName),
                    Course = sc.Course.Name
                }).ToListAsync();

            return Ok(studentCourses);
        }


        [Authorize(Policy = "AdminOnly")]
        [HttpPost("Add Course")]
        public async Task<IActionResult> AddCourse([FromBody] StudentCourseModel studentCourseModel)
        {
            StudentCourseValidator validator = new StudentCourseValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(studentCourseModel);

            if (validationResult.IsValid)
            {
                var studentCourse = _mapper.Map<StudentCourse>(studentCourseModel);

                await _unitOfWork.StudentCourseRepository.Add(studentCourse);
                await _unitOfWork.Save();

                return Ok(studentCourse);
            }
            else
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage);
                return BadRequest(errors);
            }

        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("Update Student Course")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] StudentCourseModel studentCourseModel)
        {
            StudentCourseValidator validator = new StudentCourseValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(studentCourseModel);

            if (validationResult.IsValid)
            {
                var studentCourse = await _unitOfWork.StudentCourseRepository.Find(id);

                if (studentCourse is null) return NotFound();

                _mapper.Map(studentCourseModel, studentCourse);

                await _unitOfWork.StudentCourseRepository.Update(studentCourse);
                await _unitOfWork.Save();
                return Ok(studentCourse);

            }
            else
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage);
                return BadRequest(errors);
            }
            
        }


        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("Delete Student Course")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var studentCourse = await _unitOfWork.StudentCourseRepository.Find(id);

            if (studentCourse is null) return NotFound();

            await _unitOfWork.StudentCourseRepository.Delete(studentCourse);
            await _unitOfWork.Save();

            return Ok();
        }
    }

}

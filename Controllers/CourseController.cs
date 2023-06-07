using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Data.UnitOfWork;
using StudentsCoursesManager.Models;

namespace StudentsCoursesManager.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CourseModel> _validator;
        
        public CourseController(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CourseModel> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;

        }



        [HttpGet("Get Courses")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _unitOfWork.CourseRepository.GetAllList();
            var courseModels = courses.Select(course => _mapper.Map<CourseModel>(course));
            return Ok(courseModels);
        }

        [HttpGet("Get Course By Id")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _unitOfWork.CourseRepository.Find(id);
            var courseModel = _mapper.Map<CourseModel>(course);

            return Ok(courseModel);
        }

        [HttpPost("Create Course")]
        public async Task<IActionResult> CreateStudent([FromBody] CourseModel courseModel, [FromServices] IOptions<ApiBehaviorOptions> apiBehaviour)
        {
            if (ModelState.IsValid)
            {

                var course = _mapper.Map<Course>(courseModel);

                await _unitOfWork.CourseRepository.Add(course);
                await _unitOfWork.Save();

                return Ok(course);
            }
            return apiBehaviour.Value.InvalidModelStateResponseFactory(ControllerContext);
        }

        [HttpPut("Update Course")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseModel courseModel, [FromServices] IOptions<ApiBehaviorOptions> apiBehaviour)
        {

            if (ModelState.IsValid)
            {

                var course = await _unitOfWork.CourseRepository.Find(id);

                _mapper.Map(courseModel, course);

                await _unitOfWork.CourseRepository.Update(course);
                await _unitOfWork.Save();
                return Ok(course);
            }
            return apiBehaviour.Value.InvalidModelStateResponseFactory(ControllerContext);

        }

        [HttpDelete("Delete Course")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var course = await _unitOfWork.CourseRepository.Find(id);

            await _unitOfWork.CourseRepository.Delete(course);
            await _unitOfWork.Save();
            return Ok(course);

        }
    }
}


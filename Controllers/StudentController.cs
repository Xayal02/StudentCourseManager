using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentsCoursesManager.Data.Common;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Data.UnitOfWork;
using StudentsCoursesManager.Data.Validators;
using StudentsCoursesManager.Models;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentsCoursesManager.Controllers
{
    [Authorize("AdminOnly")]

    //[Authorize(Roles ="Admin")]
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<StudentModel> _validator;

        public StudentController(IUnitOfWork unitOfWork, IMapper mapper, IValidator<StudentModel> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;

        }
        [HttpGet("Get Students")]
        public async Task<IActionResult> GetStudents()
        {
            var students= await _unitOfWork.StudentRepository.GetAllList();

            var studentModels = students.Select(student => _mapper.Map<StudentModel>(student));
            return Ok(studentModels);
        }

        [HttpGet("Get Student By Id")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _unitOfWork.StudentRepository.Find(id);

            if (student is null) return NotFound();

            var studentModel =  _mapper.Map<StudentModel>(student);

            return Ok(studentModel);
        }

        [HttpPost("Create Student")]
        public async Task<IActionResult> CreateStudent([FromBody] StudentModel studentModel, [FromServices] IOptions<ApiBehaviorOptions> apiBehaviour)
        {
            var validationResult = await _validator.ValidateAsync(studentModel);

            if (validationResult.IsValid)
            {
                var student = _mapper.Map<Student>(studentModel);

                await _unitOfWork.StudentRepository.Add(student);
                await _unitOfWork.Save();

                return Ok(student);
            }
            return apiBehaviour.Value.InvalidModelStateResponseFactory(ControllerContext);
        }

        [HttpPut("Update Student")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentModel studentModel, [FromServices] IOptions<ApiBehaviorOptions> apiBehaviour)
        {
            var validationResult = await _validator.ValidateAsync(studentModel);

            if (validationResult.IsValid)
            {

                var student = await _unitOfWork.StudentRepository.Find(id);

                if (student is null) return NotFound();

                _mapper.Map(studentModel, student);

                await _unitOfWork.StudentRepository.Update(student);
                await _unitOfWork.Save();
                return Ok(student);
            }
            return apiBehaviour.Value.InvalidModelStateResponseFactory(ControllerContext);

        }

        [HttpDelete("Delete Student")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _unitOfWork.StudentRepository.Find(id);

            if (student is null) return NotFound();

            await _unitOfWork.StudentRepository.Delete(student);
            await _unitOfWork.Save();
            return Ok(student);

        }
    }
}

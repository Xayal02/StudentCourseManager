using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentsCoursesManager.Application.Commands.StudentCourseCommands;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Application.Queries.StudentCoursesQueries;

namespace StudentsCoursesManager.Controllers
{
    [Authorize(Policy = "AuthenticatedUser")]
    public class StudentCourseController : Controller
    {
        private readonly IMediator _mediator;

        public StudentCourseController(IMediator mediator)
        {
           _mediator = mediator;
        }


        [HttpGet("Get Current Courses")]
        public async Task<IActionResult> GetCourses()
        {
            var query = new GetAllStudentCoursesQuery();
            var result = _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("Get Course By Student Id")]
        public async Task<IActionResult> GetCourseByStudentId(int studentId, CancellationToken cancellationToken)
        {
            var query = new GetAllStudentCoursesQueryByStudentId(studentId);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound("Course with such id doesnt exist");
        }

        [HttpGet("Get Course By Course Id")]
        public async Task<IActionResult> GetCourseByCourseId(int courseId, CancellationToken cancellationToken)
        {
            var query = new GetAllStudentCoursesByCourseIdQuery(courseId);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound("Course with such id doesnt exist");

        }


        [Authorize(Policy = "AdminOnly")]
        [HttpPost("Add Course")]
        public async Task<IActionResult> AddCourse([FromBody] StudentCourseModel studentCourseModel)
        {
            var query = new CreateStudentCourseCommand(studentCourseModel);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("Update Student Course")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] StudentCourseModel studentCourseModel)
        {
            var query = new UpdateStudentCourseCommand(id, studentCourseModel);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound("Course with such id doesnt exist");
        }


        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("Delete Student Course")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var query = new DeleteStudentCourseCommand(id);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound("Course with such id doesnt exist");
        }
    }

}

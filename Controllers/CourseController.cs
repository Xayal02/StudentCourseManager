using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentsCoursesManager.Application.Models;
using StudentsCoursesManager.Commands;
using StudentsCoursesManager.Commands.CourseCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Helpers.Exceptions;
using StudentsCoursesManager.Persistence;
using StudentsCoursesManager.Queries;
using StudentsCoursesManager.Queries.CourseQueries;

namespace StudentsCoursesManager.Controllers
{
    //[Authorize(Policy = "AuthenticatedUser")]
    public class CourseController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CourseController> _logger;
        
        public CourseController(IMediator mediator, ILogger<CourseController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet("Get Courses")]
        public async Task<IActionResult> GetCourses()
        {
            var query = new GetAllCoursesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("Get Course By Id/{id}")]
        public async Task<IActionResult> GetCourseById(int id, CancellationToken cancellationToken)
        {
            var query = new GetCourseByIdQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound("Course with such id doesnt exist");
        }


        //[Authorize(Policy = "AdminOnly")]
        [HttpPost("Create Course")]
        public async Task<IActionResult> CreateCourse([FromBody] CourseModel courseModel, [FromServices] IOptions<ApiBehaviorOptions> apiBehaviour)
        {
            var command = new CreateCourseCommand(courseModel);
            var result = await _mediator.Send(command);
            _logger.LogWarning("Course Created");
            return Ok(result);
        }


        [Authorize(Policy = "AdminOnly")]
        [HttpPut("Update Course/{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseModel courseModel)
        {
            var command = new UpdateCourseCommand(id, courseModel);
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("Delete Course/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var command = new DeleteCourseCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}


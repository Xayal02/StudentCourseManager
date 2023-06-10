﻿using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentsCoursesManager.Commands.StudentCommands;
using StudentsCoursesManager.Data.Entities;
using StudentsCoursesManager.Data.Validators;
using StudentsCoursesManager.Models;
using StudentsCoursesManager.Persistence;
using StudentsCoursesManager.Queries.StudentQueries;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentsCoursesManager.Controllers
{
    [Authorize(Policy = "AuthenticatedUser")]
    public class StudentController : Controller
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet("Get Students")]
        public async Task<IActionResult> GetStudents()
        {
            var query = new GetAllStudentsQuery();
            var result = _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("Get Student By Id")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var query = new GetStudentByIdQuery(id);
            var result = _mediator.Send(query);
            return result != null ? Ok(result) : NotFound("Course with such id doesnt exist");

        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost("Create Student")]
        public async Task<IActionResult> CreateStudent([FromBody] StudentModel studentModel, [FromServices] IOptions<ApiBehaviorOptions> apiBehaviour)
        {
            var query = new CreateStudentCommand(studentModel);
            var result = _mediator.Send(query);
            return Ok(result);
        }


        [Authorize(Policy = "AdminOnly")]
        [HttpPut("Update Student")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentModel studentModel, [FromServices] IOptions<ApiBehaviorOptions> apiBehaviour)
        {
            var query = new UpdateStudentCommand(studentModel,id);
            var result = _mediator.Send(query);
            return Ok(result);
        }


        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("Delete Student")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var query = new DeleteStudentCommand(id);
            var result = _mediator.Send(query);
            return Ok(result);
        }
    }
}

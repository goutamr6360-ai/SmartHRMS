using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHRMS.Application.Features.Employees.Commands.CreateEmployee;
using SmartHRMS.Application.Features.Employees.Commands.DeleteEmployee;
using SmartHRMS.Application.Features.Employees.Commands.UpdateEmployee;
using SmartHRMS.Application.Features.Employees.Queries.GetAllEmployees;
using SmartHRMS.Application.Features.Employees.Queries.GetEmployeeById;
using SmartHRMS.Domain.Entities;
using SmartHRMS.Shared.Responses;

namespace SmartHRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand command)
        {
            var employeeId = await _mediator.Send(command);

            var response = new ApiResponse<Guid>
            {
                Success = true,
                Message = "Employee created successfully.",
                Data = employeeId
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));

            return Ok(new ApiResponse<EmployeeDto>
            {
                Success = true,
                Message = "Employee fetched successfully.",
                Data = employee
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(new ApiResponse<List<EmployeeListDto>>
            {
                Success = true,
                Message = "Employee fetched successfully.",
                Data = employees
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> update(Guid id,[FromBody] UpdateEmployeeCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Route id and Request id do not match",
                    Data = null,
                    Errors = new List<string> { "Invalid employee id." }
                });
            }
            var employeeId = await _mediator.Send(command);
            return Ok(new ApiResponse<Guid>
            {
                Success = true,
                Message = "Employee updated successfully.",
                Data = employeeId
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employeeId = await _mediator.Send(new DeleteEmployeeCommand(id));

            return Ok(new ApiResponse<Guid>
            {
                Success = true,
                Message = "Employee deleted successfully.",
                Data = employeeId
            });
        }
    }
}

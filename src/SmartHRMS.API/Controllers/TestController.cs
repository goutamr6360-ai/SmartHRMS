using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHRMS.Application.Exceptions;
using SmartHRMS.Shared.Responses;

namespace SmartHRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            throw new Exception("This is a test exception from TestController.");
            //var response = new ApiResponse<string>
            //{
            //    Success = true,
            //    Message = "API is working successfully",
            //    Data = "Welcome to SmartHRMS AI"
            //};
            //return Ok(response);
        }

        [HttpGet("not-found")]
        public IActionResult NotFoundTest()
        {
            throw new DirectoryNotFoundException("Employee not found.");
        }

        [HttpGet("validation")]
        public IActionResult ValidationTest()
        {
            throw new ValidationException(
                "Validation Failed.",
                new List<string>
                {
                    "Employee name is required.",
                    "Email format is invalid."
                });
        }

        [HttpGet("server-error")]
        public IActionResult ServerErrorTest()
        {
            throw new Exception("Unexpected database connection error.");
        }
    }
}

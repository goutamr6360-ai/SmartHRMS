using SmartHRMS.Shared.Responses;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using SmartHRMS.Application.Exceptions;

namespace SmartHRMS.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next,ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                if (context.Response.HasStarted)
                {
                    _logger.LogWarning("The response has already started, cannot write exception response");
                    throw;
                }
                await HandleExceptionAsync(context, e);
            }
        }

        public static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = new ApiResponse<object>
            {
                Success = false,
                Data = null
            };
            switch (ex)
            {
                case SmartHRMS.Application.Exceptions.ValidationException validationException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = validationException.Message;
                    response.Errors = validationException.Errors;
                    break;
                case NotFoundException notFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = notFoundException.Message;
                    response.Errors = new List<string> { notFoundException.Message };
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Message = "An unexpected error occurred";
                    response.Errors = new List<string> { ex.Message };
                    break;
            }
            //context.Response.ContentType = "application/json";
            //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //var response = new ApiResponse<object>
            //{
            //    Success = true,
            //    Message = "An Unexpected error occured",
            //    Data = null,
            //    Errors = new List<string> { ex.Message }
            //};
            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}

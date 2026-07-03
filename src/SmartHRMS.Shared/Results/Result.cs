using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHRMS.Shared.Results
{
    public class Result
    {
        public bool IsSuccess { get; protected set; }
        public bool IsFailure => !IsSuccess;
        public string Message { get; protected set; } = string.Empty;
        public List<string> Errors { get; protected set; } = new();

        protected Result(bool isSuccess, string message, List<string>? errors = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Errors = errors ?? new List<string>();
        }

        public static Result Sucess(string message = "Operation Completed Successfully")
        {
            return new Result(true, message);
        }

        public static Result Failure(string message, List<string>? errors = null)
        {
            return new Result(false, message,errors);
        }
    }
}

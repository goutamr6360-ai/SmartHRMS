using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHRMS.Shared.Results
{
    public class Result<T> : Result
    {
        public T? Data { get; private set; }

        public Result(bool isSuccess, 
            T? data, string message,
            List<string>? errors = null) : base(isSuccess,message,errors)
        {
            Data = data;
        }

        public static Result<T> Success(T data,string message = "Operation completed successfully")
        {
            return new Result<T>(true, data, message);
        }

        public static new Result<T> Failure(string message,List<string>? errors = null)
        {
            return new Result<T>(false, default, message, errors);
        }
    }
}

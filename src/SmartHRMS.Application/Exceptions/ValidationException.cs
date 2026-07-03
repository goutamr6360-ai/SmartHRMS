using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHRMS.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }
        public ValidationException(string message, List<string>? errors = null) : base(message)
        {
            Errors = errors ?? new List<string>();
        }
    }
}

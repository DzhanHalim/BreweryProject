using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }

        // when this ctor gets executed, it executes the ctor with succes parameter aswel thanks to this keyword
        // this ctor works together with the second ctor
        public Result(bool success, string message) : this(success)
        {

            Message = message;
        }
        public Result(bool success)
        {
            Success = success;

        }

    }
}

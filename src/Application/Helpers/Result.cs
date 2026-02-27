using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class Result<T>
    {
        public T? Value { get; private set; } 

        public bool IsSuccess { get; private set; }

        public string? ErrorMessage { get; private set; }

        public static Result<T> Success(T? value) => new() { Value = value, IsSuccess=true };

        public static Result<T> Failure(string error) => new() { ErrorMessage = error, IsSuccess=false };
    }
}

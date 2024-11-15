using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Test.Models.Responses.Common
{
    public class Result
    {
        protected ErrorResponse _errorResponse;
        public bool IsSuccess { get => _errorResponse == null; }
        public bool IsFailure { get => !IsSuccess; }
        public ErrorResponse Error { get => _errorResponse; }

        [JsonIgnore]
        public HttpStatusCode? StatusCode { get; set; }

        protected Result(ErrorResponse error, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            _errorResponse = error;
            StatusCode = httpStatusCode;
        }
        protected Result()
        {
            _errorResponse = null;
            StatusCode = HttpStatusCode.OK;
        }
        public static Result FromFailure(ErrorResponse error, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest) => new Result(error, httpStatusCode);
        public static Result FromSuccess() => new Result();

        public static implicit operator Result(ErrorResponse error) { return new Result(error); }
    }

    public class Result<T> : Result
    {
        private T _value;
        public T Ok { get => _value; }

        public Result(T value) : base()
        {
            _value = value;
        }
        public Result(ErrorResponse error, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest) : base(error, httpStatusCode)
        {
            _value = default;
        }

        public static implicit operator Result<T>(T value) { return new Result<T>(value); }
        public static implicit operator Result<T>(ErrorResponse error) { return new Result<T>(error); }

        public static new Result<T> FromFailure(ErrorResponse error, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest) => new Result<T>(error, httpStatusCode);
        public static Result<T> FromFailure(Result result) => new Result<T>(result.Error);
        public static Result<T> FromSuccess(T value) => new Result<T>(value);
    }
}

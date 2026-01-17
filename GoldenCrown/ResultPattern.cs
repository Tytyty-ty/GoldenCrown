using Microsoft.AspNetCore.Http.HttpResults;

namespace GoldenCrown
{
    public record Result
    {
        public bool IsSuccess { get; }
        public ErrorCodes ErrorCode { get; }
        public string ErrorMessage { get; }

        protected Result(bool isSuccess, ErrorCodes errorCode, string errorMessage)
        {
            switch (isSuccess)
            {
                case true when errorCode != ErrorCodes.None:
                    throw new InvalidOperationException(message: "It seems someone wants to catch a non-empty error message when it's true");
                case false when errorCode == ErrorCodes.None:
                    throw new InvalidOperationException(message: "It seems someone wants to catch an empty error message when it's false");

                default:
                    IsSuccess = isSuccess;
                    ErrorCode = errorCode;
                    ErrorMessage = errorMessage;
                    break;
            }
        }

        public static Result Success() => new(isSuccess: true, errorCode: ErrorCodes.None, errorMessage: String.Empty);
        public static Result Failure(ErrorCodes errorCode, string errorMessage) => new(isSuccess: false, errorCode: errorCode, errorMessage: errorMessage);

        public static implicit operator bool(Result result) => result.IsSuccess;


    }
    public record Result<T> : Result
    {
        public T? Value { get; init; }

        protected Result(T? value, bool isSuccess, ErrorCodes errorCode, string errorMessage) : base(isSuccess, errorCode, errorMessage) => Value = value;

        public static Result<T> Success(T value) => new(value: value, isSuccess: true, errorCode: ErrorCodes.None, errorMessage: String.Empty);

        public static new Result<T> Failure(ErrorCodes errorCode, string errorMessage) => new(value: default, isSuccess: false, errorCode: errorCode, errorMessage: errorMessage);
    }

    public enum ErrorCodes
    {
        None,
        BadRequest,
        NotFound,
        Unauthorized,
        Conflict,
        Validation,
        Unknown
    }

}

using FluentValidation.Results;

namespace ApiCompras.Application.Services;

public class ResultService
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public ICollection<ErrorValidation> Errors { get; set; }

    public static ResultService RequestError(string message, ValidationResult validationResult)
    {
        return new ResultService
        {
            IsSuccess = false,
            Message = message,
            Errors = validationResult.Errors.Select(x => new ErrorValidation
            {
                Field = x.PropertyName,
                Message = x.ErrorMessage
            }).ToList()
        };
    }
    public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult) where T : class
    {
        return new ResultService<T>
        {
            IsSuccess = false,
            Message = message,
            Errors = validationResult.Errors.Select(x => new ErrorValidation
            {
                Field = x.PropertyName,
                Message = x.ErrorMessage
            }).ToList()
        };
    }

    public static ResultService Fail(string message)
        => new ResultService { IsSuccess = false, Message = message };
    public static ResultService<T> Fail<T>(string message) where T : class
        => new ResultService<T> { IsSuccess = false, Message = message };

    public static ResultService Ok(string message)
        => new ResultService { IsSuccess = true, Message = message };
    public static ResultService<T> Ok<T>(T data) where T : class
        => new ResultService<T> { IsSuccess = true, Data = data };

}

public class ResultService<T> : ResultService where T : class
{
    public T Data { get; set; }
}

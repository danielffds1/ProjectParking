namespace Parking.Core.Domain.Common
{
    public class BaseOutput<T>
    {
        public BaseOutput()
        {
            IsSuccess = true;
            BusinessRuleViolation = false;
        }
        public BaseOutput(string message)
        {
            IsSuccess = false;
            BusinessRuleViolation = true;
            Message = message;
        }
        public BaseOutput(string message, bool success, bool businessRuleViolation)
        {
            IsSuccess = success;
            Message = message;
            BusinessRuleViolation = businessRuleViolation;
        }
        public BaseOutput(T data, string message = null, bool businessRuleViolation = false)
        {
            IsSuccess = true;
            Message = message;
            Data = data;
            BusinessRuleViolation = businessRuleViolation;
        }
        public T Value { get; } = default!;
        public BaseOutput(T data)
        {
            IsSuccess = true;
            Data = data;
            BusinessRuleViolation = false;
        }

        public static BaseOutput<T> Success(T value)
        {
            return new BaseOutput<T>(value);
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public bool BusinessRuleViolation { get; set; }
        public T Data { get; set; }
    }
}

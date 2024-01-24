using FluentValidation.Results;


namespace Ordering.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; }
        public ValidationException() 
            : base("ONe or more validation failures have occured.")
        {
            Errors = new Dictionary<String, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            :this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key,failureGroup => failureGroup.ToArray());
        }
    }
}

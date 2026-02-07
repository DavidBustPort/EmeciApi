using System.Net;

namespace Application.Common.Exceptions
{
    public class ValidationException(string message) : BaseException(message)
    {
        public override int StatusCode => (int)HttpStatusCode.BadRequest;
    }
}

using Application.Common.Wrappers;
using MediatR;

namespace Application.Common.Interfaces
{
    public interface IApiRequestHandler<TRequest, TResponse>
        : IRequestHandler<TRequest, Result<TResponse>>
        where TRequest : IApiRequest<TResponse>
    {
    }
}

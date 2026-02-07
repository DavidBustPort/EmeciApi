using Application.Common.Wrappers;
using MediatR;

namespace Application.Common.Interfaces
{
    public interface IApiRequest<T> : IRequest<Result<T>> { }
}

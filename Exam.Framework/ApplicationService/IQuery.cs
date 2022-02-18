using MediatR;

namespace Exam.Framework.ApplicationService
{
    public interface IQuery<TResponse> : IRequest<ApplicationServiceResult<TResponse>>
    {

    }
}

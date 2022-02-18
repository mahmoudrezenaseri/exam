using MediatR;

namespace Exam.Framework.ApplicationService
{
    public interface ICommand<TResponse> : IRequest<ApplicationServiceResult<TResponse>>
    {
    
    }
}

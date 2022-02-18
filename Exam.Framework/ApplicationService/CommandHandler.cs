using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Exam.Framework.ApplicationService
{
    public abstract class CommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, ApplicationServiceResult<TResponse>>
        where TRequest : ICommand<TResponse>
    {
        public IMapper Mapper { get; set; }
        public IServiceProvider ServiceProvider { get; }

        public CommandHandler(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            Mapper = (IMapper)serviceProvider.GetService(typeof(IMapper));
        }
        public async Task<ApplicationServiceResult<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (!IsValidRequest(request, out IEnumerable<string> messages))
                    return ValidationError(messages.ToArray());

                return await HandleCommand(request, cancellationToken);
            }
            catch (Exception)
            {
                var traceId = Guid.NewGuid().ToString();
                // TODO : log error by traceId
                return Exception($"there is an unhandled error. reference id is {traceId}");
            }
        }

        private bool IsValidRequest(TRequest request, out IEnumerable<string> messages)
        {
            messages = new List<string>();

            var validatorFactory = (IValidatorFactory)ServiceProvider.GetService(typeof(IValidatorFactory));
            var validator = validatorFactory.GetValidator<TRequest>();
            if (validator == null)
                return true;

            var validationResult = validator.Validate(request);

            messages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            return validationResult.IsValid;
        }

        public abstract Task<ApplicationServiceResult<TResponse>> HandleCommand(TRequest request, CancellationToken cancellationToken);

        public static ApplicationServiceResult<TResponse> Ok(TResponse response) => ApplicationServiceResult<TResponse>.Ok(response);
        public static ApplicationServiceResult<TResponse> ValidationError(params string[] messages) => ApplicationServiceResult<TResponse>.Failed(ApplicationServiceResultStatus.ValidationError, messages);
        public static ApplicationServiceResult<TResponse> NotFound() => ApplicationServiceResult<TResponse>.Failed(ApplicationServiceResultStatus.Notfound);
        public static ApplicationServiceResult<TResponse> Exception(params string[] messages) => ApplicationServiceResult<TResponse>.Failed(ApplicationServiceResultStatus.Exception, messages);
    }
}

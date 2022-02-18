using System.Collections.Generic;

namespace Exam.Framework.ApplicationService
{
    public class ApplicationServiceResult<TData>
    {
        public ApplicationServiceResultStatus Status { get; set; }
        public bool IsSucceded => Status == ApplicationServiceResultStatus.Ok;
        public IEnumerable<string> Messages { get; set; }
        public TData Data { get; set; }

        public ApplicationServiceResult()
        {
            Messages = new List<string>();
        }
        public static ApplicationServiceResult<TData> Ok(TData data) => new ApplicationServiceResult<TData>()
        {
            Data = data,
            Status = ApplicationServiceResultStatus.Ok
        };

        public static ApplicationServiceResult<TData> Failed(ApplicationServiceResultStatus status, params string[] messages) => new ApplicationServiceResult<TData>()
        {
            Data = default(TData),
            Status = status,
            Messages = messages
        };
    }
}

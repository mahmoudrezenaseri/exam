using System.Collections.Generic;

namespace Exam.Framework.ApplicationService
{
    public interface IValidatabe
    {
        IEnumerable<string> Validate();
    }
}

using System;
using System.Threading.Tasks;

namespace Convesys.Kernel.Security.Validation
{
    public interface IBackchannelCertificateValidationRule
    {
        Task Validate(BackchannelCertificateValidationContext context, Func<BackchannelCertificateValidationContext, Task> next);
    }
}
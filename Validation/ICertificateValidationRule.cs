using System;
using System.Threading.Tasks;

namespace Convesys.Kernel.Security.Validation
{
    public interface ICertificateValidationRule
    {
        Task Validate(CertificateValidationContext context, Func<CertificateValidationContext, Task> next);
    }
}
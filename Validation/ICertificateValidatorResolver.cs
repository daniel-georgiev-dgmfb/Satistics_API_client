using System;
using System.Collections.Generic;
using Convesys.Kernel.Security.Configuration;

namespace Convesys.Kernel.Security.Validation
{
    public interface ICertificateValidatorResolver
    {
        IEnumerable<TValidator> Resolve<TValidator>(Uri partnerId) where TValidator : class;
        IEnumerable<IPinningSertificateValidator> Resolve(BackchannelConfiguration configuration); 
        
    }
}
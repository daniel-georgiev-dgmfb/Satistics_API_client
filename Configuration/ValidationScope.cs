using System;

namespace Convesys.Kernel.Security.Configuration
{
    [Flags]
    public enum ValidationScope
    {
        Certificate = 1,
        BackchannelCertificate= 2
    }
}
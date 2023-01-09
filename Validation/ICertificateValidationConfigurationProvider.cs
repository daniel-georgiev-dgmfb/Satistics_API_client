using System;
using Convesys.Kernel.Security.Configuration;

namespace Convesys.Kernel.Security.Validation
{
    public interface ICertificateValidationConfigurationProvider : IDisposable
    {
        CertificateValidationConfiguration GetConfiguration(string federationPartyId);
        BackchannelConfiguration GeBackchannelConfiguration(string federationPartyId);
        BackchannelConfiguration GeBackchannelConfiguration(Uri partyUri);
    }
}
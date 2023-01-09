using Convesys.Kernel.Security.Configuration;
using System;

namespace Satistics_API_client
{
    public interface ICertificateValidationConfigurationProvider
    {
        BackchannelConfiguration GeBackchannelConfiguration(string federationPartyId);
        BackchannelConfiguration GeBackchannelConfiguration(Uri partyUri);
        CertificateValidationConfiguration GetConfiguration(string federationPartyId);
    }
}
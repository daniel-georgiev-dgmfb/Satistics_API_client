﻿using System;
using Twilight.Kernel.Security.Configuration;
using Twilight.Kernel.Security.Validation;

namespace Satistics_API_client
{
    public class CertificateValidationConfigurationProvider : ICertificateValidationConfigurationProvider
    {
        public BackchannelConfiguration GeBackchannelConfiguration(string federationPartyId)
        {
            return new BackchannelConfiguration
            {
                UsePinningValidation = false
            };
        }

        public BackchannelConfiguration GeBackchannelConfiguration(Uri partyUri)
        {
            return new BackchannelConfiguration
            {
                UsePinningValidation = false
            };
        }

        public CertificateValidationConfiguration GetConfiguration(string federationPartyId)
        {
            return new CertificateValidationConfiguration();
        }

        public void Dispose()
        {
        }
    }
}

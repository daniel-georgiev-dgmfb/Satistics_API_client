﻿using System.Security.Cryptography.X509Certificates;

namespace Convesys.Kernel.Security.CertificateManagement
{
    public class CertificateSearchCriteria
    {
        public object SearchValue { get; set; }
        public X509FindType SearchCriteriaType { get; set; }
    }
}
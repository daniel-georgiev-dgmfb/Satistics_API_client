using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Satistics_API_client
{
    public class BackchannelCertificateValidator : Twilight.Kernel.Security.Validation.IBackchannelCertificateValidator
    {
        public bool Validate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}

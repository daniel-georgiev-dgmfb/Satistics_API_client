using System.Security;
using System.Security.Cryptography.X509Certificates;
using Convesys.Kernel.Security.Validation;

namespace Convesys.Kernel.Security.CertificateManagement
{
    public interface ICertificateManager
    {
        IBackchannelCertificateValidator BackchannelCertificateValidator { get; }
        X509Certificate2 GetCertificate(string path, SecureString password);
        X509Certificate2 GetCertificate(ICertificateStore store);
        bool TryExtractSpkiBlob(X509Certificate2 certificate, out string spkiEncoded);
        string GetSubjectKeyIdentifier(X509Certificate2 certificate);
        string GetCertificateThumbprint(X509Certificate2 certificate);
        TResolver GetX509CertificateStoreTokenResolver<TResolver>(X509CertificateContext x509CertificateContext);
        ICertificateStore GetStoreFromContext(CertificateContext certContext);
        X509Certificate2 GetCertificateFromContext(CertificateContext certContext);
        string SignToBase64(string dataToSign, CertificateContext certContext);
        byte[] SignData(string dataToSign, X509Certificate2 certificate);
        bool VerifySignatureFromBase64(string data, string signed, CertificateContext certContext);
        bool VerifySignatureFromBase64(string data, string signed, X509Certificate2 certificate);
        bool TryAddCertificateToStore(string storeName, StoreLocation location, X509Certificate2 certificate, bool createIfNotExist);
    }
}
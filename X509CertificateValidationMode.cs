namespace Convesys.Kernel.Security.Security
{
    public enum X509CertificateValidationMode
    {
        //
        // Summary:
        //     No validation of the certificate is done.
        None = 0,
        //
        // Summary:
        //     The certificate is valid if it is in the trusted people store.
        PeerTrust = 1,
        //
        // Summary:
        //     The certificate is valid if the chain builds to a certification authority in
        //     the trusted root store.
        ChainTrust = 2,
        //
        // Summary:
        //     The certificate is valid if it is in the trusted people store, or if the chain
        //     builds to a certification authority in the trusted root store.
        PeerOrChainTrust = 3,
        //
        // Summary:
        //     The user must plug in a custom System.IdentityModel.Selectors.X509CertificateValidator
        //     to validate the certificate.
        Custom = 4
    }
}
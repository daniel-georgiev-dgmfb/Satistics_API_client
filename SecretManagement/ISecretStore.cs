using System.Threading.Tasks;

namespace Convesys.Kernel.Security.SecretManagement
{
    public interface ISecretStore
    {
        string StoreLocation { get; }
        Task<string> GetSecret(SecretContext secretContext);
    }
}
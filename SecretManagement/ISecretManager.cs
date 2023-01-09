using System.Threading.Tasks;

namespace Convesys.Kernel.Security.SecretManagement
{
    public interface ISecretManager
    {
        Task<string> GetSecret(SecretContext secretContext);
        Task<string> GetSecret(string secretName);
        Task<string> GetSecret(string secretName, string version);
    }
}
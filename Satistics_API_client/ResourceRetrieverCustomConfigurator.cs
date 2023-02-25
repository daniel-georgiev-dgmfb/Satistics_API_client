using System;
using Twilight.Kernel.Configuration;
using Twilight.Kernel.Web;

namespace Satistics_API_client
{
    internal class ResourceRetrieverCustomConfigurator : ICustomConfigurator<IHttpResourceRetriever>
    {
        public void Configure(IHttpResourceRetriever configurable)
        {
            configurable.RequireHttps = false;
#if DEBUG
            configurable.Timeout = TimeSpan.FromSeconds(100);
#else
            configurable.Timeout = TimeSpan.FromSeconds(10);
#endif
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Rftim3Convoy.API
{
    internal class APIHostBase : IAPIHostBase
    {
        public void RunAPIHostBase(IHost host) => RunAPIHostBase0(host.Services);

        private static void RunAPIHostBase0(IServiceProvider hostProvider)
        {
            using IServiceScope serviceScope = hostProvider.CreateScope();
            IServiceProvider serviceProvider = serviceScope.ServiceProvider;
        }
    }
}

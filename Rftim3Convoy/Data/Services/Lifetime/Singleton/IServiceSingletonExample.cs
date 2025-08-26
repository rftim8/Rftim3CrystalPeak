using Microsoft.Extensions.DependencyInjection;

namespace Rftim3Convoy.Data.Services.Lifetime.Singleton
{
    public interface IServiceSingletonExample : IServiceReportLifetime
    {
        ServiceLifetime IServiceReportLifetime.Lifetime => ServiceLifetime.Singleton;
    }
}

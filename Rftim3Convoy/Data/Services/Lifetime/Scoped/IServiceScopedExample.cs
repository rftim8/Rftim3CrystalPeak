using Microsoft.Extensions.DependencyInjection;

namespace Rftim3Convoy.Data.Services.Lifetime.Scoped
{
    public interface IServiceScopedExample : IServiceReportLifetime
    {
        ServiceLifetime IServiceReportLifetime.Lifetime => ServiceLifetime.Scoped;
    }
}

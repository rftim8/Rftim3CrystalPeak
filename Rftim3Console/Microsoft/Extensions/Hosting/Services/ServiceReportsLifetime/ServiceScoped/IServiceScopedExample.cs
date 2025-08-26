using Microsoft.Extensions.DependencyInjection;

namespace Rftim3Console.Microsoft.Extensions.Hosting.Services.ServiceReportsLifetime.ServiceScoped
{
    public interface IServiceScopedExample : IServiceReportLifetime
    {
        ServiceLifetime IServiceReportLifetime.Lifetime => ServiceLifetime.Scoped;
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace Rftim3Console.Microsoft.Extensions.Hosting.Services.ServiceReportsLifetime.ServiceTransient
{
    public interface IServiceTransientExample : IServiceReportLifetime
    {
        ServiceLifetime IServiceReportLifetime.Lifetime => ServiceLifetime.Transient;
    }
}

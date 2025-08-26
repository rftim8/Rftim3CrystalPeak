using Microsoft.Extensions.DependencyInjection;

namespace Rftim3Console.Microsoft.Extensions.Hosting.Services.ServiceReportsLifetime
{
    public interface IServiceReportLifetime
    {
        Guid Id { get; }

        ServiceLifetime Lifetime { get; }
    }
}

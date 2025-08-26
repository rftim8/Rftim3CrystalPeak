using Microsoft.Extensions.DependencyInjection;

namespace Rftim3Convoy.Data.Services.Lifetime
{
    public interface IServiceReportLifetime
    {
        Guid Id { get; }

        ServiceLifetime Lifetime { get; }
    }
}

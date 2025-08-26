namespace Rftim3Console.Microsoft.Extensions.Hosting.Services.ServiceReportsLifetime.ServiceTransient
{
    public sealed class ServiceTransientExample : IServiceTransientExample
    {
        Guid IServiceReportLifetime.Id { get; } = Guid.NewGuid();
    }
}

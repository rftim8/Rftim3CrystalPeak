namespace Rftim3Console.Microsoft.Extensions.Hosting.Services.ServiceReportsLifetime.ServiceSingleton
{
    public sealed class ServiceSingletonExample : IServiceSingletonExample
    {
        Guid IServiceReportLifetime.Id { get; } = Guid.NewGuid();
    }
}

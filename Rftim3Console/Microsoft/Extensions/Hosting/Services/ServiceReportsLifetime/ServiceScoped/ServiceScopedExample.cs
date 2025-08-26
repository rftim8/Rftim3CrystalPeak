namespace Rftim3Console.Microsoft.Extensions.Hosting.Services.ServiceReportsLifetime.ServiceScoped
{
    public sealed class ServiceScopedExample : IServiceScopedExample
    {
        Guid IServiceReportLifetime.Id { get; } = Guid.NewGuid();
    }
}

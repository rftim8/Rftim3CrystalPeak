namespace Rftim3Convoy.Data.Services.Lifetime.Singleton
{
    public sealed class ServiceSingletonExample : IServiceSingletonExample
    {
        Guid IServiceReportLifetime.Id { get; } = Guid.NewGuid();
    }
}

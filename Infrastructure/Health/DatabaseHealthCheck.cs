using Infrastructure.Data;
using Microsoft.Extensions.Diagnostics.HealthChecks;


namespace Infrastructure.Health
{
    public class DatabaseHealthCheck(StoreContext context) : IHealthCheck
    {
        private readonly StoreContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                var canConnect = await _context.Database.CanConnectAsync(cancellationToken);
                return canConnect ? HealthCheckResult.Healthy("Database is reachable") : HealthCheckResult.Unhealthy("Database is not reachable");
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy($"An error occurred: {ex.Message}");
            }
        }


    }
}

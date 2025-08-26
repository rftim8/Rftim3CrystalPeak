using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Rftim3Tracer.Services.Databases;

namespace Rftim3Tracer.Services.Databases.MSSQL
{
    public class RftDbContextFactoryMSSQL : IDesignTimeDbContextFactory<RftDbContextMSSQL>
    {
        private IConfiguration? configuration;

        public RftDbContextMSSQL CreateDbContext(string[]? args = null)
        {
            configuration = new ConfigurationBuilder()
                .AddUserSecrets<RftDbContextMSSQL>()
                .Build();

            DbContextOptionsBuilder<RftDbContextMSSQL> dbContextOptions = new();
            dbContextOptions.UseSqlServer(configuration.GetConnectionString(IRftDBNamesService.RftDBs.RftWPF.ToString()));

            return new RftDbContextMSSQL(dbContextOptions.Options);
        }
    }
}

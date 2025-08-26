using Microsoft.EntityFrameworkCore;
using Rftim3Atlas.Models;

namespace Rftim3Tracer.Services.Databases.MSSQL
{
    public class RftDbContextMSSQL(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<RftGenericTestModel> TestTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RftGenericTestModel>()
                .Property(o => o.Id)
                .UseIdentityColumn(seed: 1, increment: 1);

            base.OnModelCreating(modelBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PanchoApp.Infrastructure.Data;

public class PanchoDbContextFactory : IDesignTimeDbContextFactory<PanchoDbContext>
{
    public PanchoDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PanchoDbContext>();

        optionsBuilder.UseSqlite("Data Source=panchoapp.db");

        return new PanchoDbContext(optionsBuilder.Options);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WpfAppGlobalShoes.Context;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GSDBContext>
{
    public GSDBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GSDBContext>();

        optionsBuilder.UseSqlServer(@"Server=DESKTOP-NOH724N;Database=GSDB;Trusted_Connection=True;TrustServerCertificate=True;");

        return new GSDBContext(optionsBuilder.Options);
    }
}

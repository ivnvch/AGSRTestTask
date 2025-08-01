using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AGSRTestTask.Persistence;

public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "AGSRTestTask.API"))
            .AddJsonFile("appsettings.json")
            .Build();


        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(connectionString);

        return new DataContext(configuration);
    }
}
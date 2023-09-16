using Microsoft.EntityFrameworkCore;

namespace WCS_Repository_DemoVersion;

public class Context : DbContext
{
    public DbSet<RegionForEFCore> Regions => Set<RegionForEFCore>();
    public DbSet<SubjectOfTheRegionForEFCore> SubjectOfTheRegions => Set<SubjectOfTheRegionForEFCore>();
    public DbSet<WeatherServiceForEFCore> WeatherServices => Set<WeatherServiceForEFCore>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegionForEFCore>(
            x =>
            {
                x.HasKey("IdRegion");
                x.Property(x => x.NameOfRegion);
                x.HasMany(x => x.AdministrativeUnits);
            }
        );
        modelBuilder.Entity<SubjectOfTheRegionForEFCore>(
            x =>
            {
                x.HasKey("IdSubject");
                x.Property(x => x.NameOfSubject);
                x.Property(x => x.RegionId);
                x.HasOne(x => x.Region);
                x.HasMany(x => x.Weather);
            }
        );
        modelBuilder.Entity<WeatherServiceForEFCore>(
            x =>
            {
                x.HasKey("IdWeatherService");
                x.Property(x => x.Date);
                x.Property(x => x.Temperature);
                x.Property(x => x.Pressure);
                x.Property(x => x.WindSpeed);
                x.Property(x => x.Precipitation);
                x.HasOne(x => x.SubjectOfTheRegion);
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        try
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=WeatherStats;Trusted_Connection=True;");
        }
        catch (Exception e)
        {
            Environment.Exit(1);
        }
    }
}
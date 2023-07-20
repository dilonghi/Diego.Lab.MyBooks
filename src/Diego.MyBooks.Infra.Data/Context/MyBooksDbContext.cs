using Diego.MyBooks.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Diego.MyBooks.Infra.Data.Context;

public class MyBooksDbContext : DbContext
{

    public MyBooksDbContext(DbContextOptions<MyBooksDbContext> options) : base(options)
    {
        
    }

    public DbSet<Reader> Reader { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<BookInReading> BookInReading { get; set; }
    


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var con = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseMySql(con, new MySqlServerVersion(new Version(8, 0, 33)));

#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
#endif
        }

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(x => x.GetProperties()
            .Where(e => e.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyBooksDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}

using Diego.MyBooks.Domain.Interfaces;
using Diego.MyBooks.Domain.Notifications;
using Diego.MyBooks.Domain.Services;
using Diego.MyBooks.Infra.Data.Context;
using Diego.MyBooks.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Diego.MyBooks.WebApi.Configurations;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MyBooksDbContext>(options =>
        options.UseMySql(configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 33))));

        services.AddScoped<INotifier, Notifier>();

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IReaderService, ReaderService>();
        services.AddScoped<IReaderRepository, ReaderRepository>();

        return services;
    }


}

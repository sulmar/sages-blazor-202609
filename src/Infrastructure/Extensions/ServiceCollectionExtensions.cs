using Domain.Abstractions;
using Infrastructure.Fakers;
using Infrastructure.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Rejestruje repozytoria w pamieci wypelnione danymi z Bogusa.
    /// Wystarczy jedna linia w Program.cs: builder.Services.AddInfrastructure();
    /// </summary>
    /// <param name="configure">Zmiana liczby encji albo opoznien.</param>
    /// <example>
    /// <code>
    /// builder.Services.AddInfrastructure();                                // 2 s, jak teraz
    /// builder.Services.AddInfrastructure(o =&gt; o.Latency = TimeSpan.Zero);  // szybkie iterowanie
    /// builder.Services.AddInfrastructure(o =&gt; { o.Latency = TimeSpan.FromSeconds(5); o.ProductsCount = 500; });
    /// </code>
    /// </example>
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        Action<InMemoryRepositoryOptions>? configure = null)
    {
        var options = new InMemoryRepositoryOptions();
        configure?.Invoke(options);

        // Singleton, a nie Scoped: dane zyja w pamieci, wiec dodanie lub usuniecie
        // encji ma byc widoczne w kolejnych zadaniach, a nie znikac razem z zakresem.
        services.AddSingleton<IProductRepository>(
            _ => new InMemoryProductRepository(new ProductFaker().Generate(options.ProductsCount), options));

        services.AddSingleton<ICustomerRepository>(
            _ => new InMemoryCustomerRepository(new CustomerFaker().Generate(options.CustomersCount), options));

        return services;
    }
}

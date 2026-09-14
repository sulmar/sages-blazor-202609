namespace Infrastructure.Repositories;

/// <summary>
/// Ustawienia repozytoriow w pamieci. Wszystkie maja wartosci domyslne,
/// wiec AddInfrastructure() bez argumentow dziala jak dotychczas.
/// </summary>
public class InMemoryRepositoryOptions
{
    /// <summary>Liczba wygenerowanych produktow.</summary>
    public int ProductsCount { get; set; } = 50;

    /// <summary>Liczba wygenerowanych klientow.</summary>
    public int CustomersCount { get; set; } = 50;

    /// <summary>
    /// Opoznienie GetAllAsync i GetByIdAsync - do cwiczenia wskaznika ladowania.
    /// Ustaw TimeSpan.Zero, zeby wylaczyc.
    /// </summary>
    public TimeSpan Latency { get; set; } = TimeSpan.FromSeconds(2);

    /// <summary>
    /// Opoznienie wyszukiwania (GetByTextAsync, GetByColorAsync) - do cwiczenia debounce.
    /// Ustaw TimeSpan.Zero, zeby wylaczyc.
    /// </summary>
    public TimeSpan SearchLatency { get; set; } = TimeSpan.FromMilliseconds(500);
}

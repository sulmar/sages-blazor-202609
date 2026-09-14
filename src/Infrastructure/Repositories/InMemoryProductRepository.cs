using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure.Repositories;

public class InMemoryProductRepository : InMemoryEntityRepository<Product>, IProductRepository
{
    public InMemoryProductRepository(IEnumerable<Product> entities, InMemoryRepositoryOptions? options = null)
        : base(entities, options)
    {
    }

    public async Task<IEnumerable<Product>> GetByColorAsync(string color)
    {
        if (string.IsNullOrEmpty(color))
            return [];

        await SimulateSearchLatencyAsync();

        return _entities.Select(p => p.Value)
            .Where(p => string.Equals(p.Color, color, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<IEnumerable<Product>> GetByTextAsync(string text)
    {
        if (string.IsNullOrEmpty(text))
            return Enumerable.Empty<Product>();

        await SimulateSearchLatencyAsync();

        return _entities.Select(p => p.Value)
            .Where(c => c.Name.Contains(text, StringComparison.OrdinalIgnoreCase)
            || c.Description.Contains(text, StringComparison.OrdinalIgnoreCase) || c.Price.ToString().Contains(text));
    }
}

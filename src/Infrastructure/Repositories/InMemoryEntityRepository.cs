using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure.Repositories;

public abstract class InMemoryEntityRepository<T> : IEntityRepository<T>
    where T : BaseEntity
{
    protected readonly IDictionary<int, T> _entities;
    protected readonly InMemoryRepositoryOptions _options;

    public InMemoryEntityRepository(IEnumerable<T> entities, InMemoryRepositoryOptions? options = null)
    {
        _entities = entities.ToDictionary(c => c.Id);
        _options = options ?? new InMemoryRepositoryOptions();
    }

    /// <summary>Udaje czas odpowiedzi serwera przy pobieraniu danych.</summary>
    protected Task SimulateLatencyAsync() => DelayAsync(_options.Latency);

    /// <summary>Udaje czas odpowiedzi serwera przy wyszukiwaniu.</summary>
    protected Task SimulateSearchLatencyAsync() => DelayAsync(_options.SearchLatency);

    // Task.Delay(TimeSpan.Zero) i tak oddaje sterowanie i przerzuca kontynuacje
    // przez scheduler, wiec wylaczone opoznienie skracamy do CompletedTask.
    private static Task DelayAsync(TimeSpan delay) =>
        delay > TimeSpan.Zero ? Task.Delay(delay) : Task.CompletedTask;

    public Task AddAsync(T entity)
    {
        _entities.Add(entity.Id, entity);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        _entities.Remove(id);

        return Task.CompletedTask;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        await SimulateLatencyAsync();

        return _entities.Values.AsEnumerable();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        await SimulateLatencyAsync();

        return _entities.TryGetValue(id, out var entity) ? entity : null;
    }

    public async Task UpdateAsync(T entity)
    {
        await DeleteAsync(entity.Id);
        await AddAsync(entity);
    }
}

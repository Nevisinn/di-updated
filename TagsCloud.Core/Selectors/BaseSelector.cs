using TagsCloud.Infrastructure.Services;

namespace TagsCloud.Infrastructure.Selectors;

public abstract class BaseSelector<T> where T : INamedService 
{
    private Dictionary<string, T> services;
    public BaseSelector(IEnumerable<T> services)
    {
        this.services = services.ToDictionary(s => s.Name);
    }
    
    public T Select(string name)
    {
        if (!services.TryGetValue(name, out var service))
            throw new ArgumentException($"Сервис по ключу {name} не найден");

        return service;
    }
}
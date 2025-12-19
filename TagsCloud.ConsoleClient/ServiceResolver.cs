using Autofac;

namespace TagsCloud;

public class ServiceResolver
{
    private readonly IComponentContext context;

    public ServiceResolver(IComponentContext context)
    {
        this.context = context;
    }

    public TService Resolve<TService>(string name) where TService : class
    {
        if (!context.TryResolveNamed<TService>(name, out var service))
            throw new ArgumentException($"Не найден {name}");

        return service;
    }
}
using System;
using System.Linq;

public class DependencyInjection
{
    public void Init()
    {
        CoreDictionary<Type, object[]> injectableTypes = new();
        foreach (var type in GetType().Assembly.GetTypes())
        {
            if (type.IsAbstract)
                continue;

            var attributes = type.GetCustomAttributes(typeof(InjectableAttribute), true);
            if (attributes.Length > 0) injectableTypes[type] = attributes;
        }

        var orderedInjectableTypes = injectableTypes.OrderBy(x => x.Key.GetPriority());
        foreach (var pair in orderedInjectableTypes)
        {
            var instance = Activator.CreateInstance(pair.Key);
            foreach (var attribute in pair.Value) ((InjectableAttribute)attribute).Inject(instance);
        }
    }
}
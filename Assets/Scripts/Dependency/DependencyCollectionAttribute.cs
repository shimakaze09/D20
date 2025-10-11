using System;
using System.Reflection;

public class DependencyCollectionAttribute : InjectableAttribute
{
    private readonly Type _type;

    public DependencyCollectionAttribute(Type type)
    {
        _type = type;
    }

    public override void Inject(object instance)
    {
        var generic = typeof(DependencyCollection<>);
        var specific = generic.MakeGenericType(_type);
        var method = specific.GetMethod("Register", BindingFlags.Public | BindingFlags.Static);
        method.Invoke(null, new[] { instance });
    }
}
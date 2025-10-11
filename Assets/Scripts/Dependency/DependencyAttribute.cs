using System;

public class DependencyAttribute : InjectableAttribute
{
    private readonly Type _type;

    public DependencyAttribute(Type type)
    {
        _type = type;
    }

    public override void Inject(object instance)
    {
        var generic = typeof(IDependency<>);
        var specific = generic.MakeGenericType(_type);
        var method = specific.GetMethod("Register", new[] { _type });
        method.Invoke(null, new[] { instance });
    }
}
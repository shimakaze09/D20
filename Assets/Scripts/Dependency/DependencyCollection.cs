public class DependencyCollection<T>
{
    public static PriorityList<T> Collection { get; } = new();

    public static void Register(T instance)
    {
        Collection.Add(instance);
    }
}
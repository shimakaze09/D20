public interface IEntrySystem : IDependency<IEntrySystem>
{
    void SetName(string name);
    string GetName();
}

public class EntrySystem : IEntrySystem
{
    public void SetName(string name)
    {
        IDataSystem.Resolve().Data.entryName = name;
    }

    public string GetName()
    {
        return IDataSystem.Resolve().Data.entryName;
    }
}

public partial class Data
{
    public string entryName;
}
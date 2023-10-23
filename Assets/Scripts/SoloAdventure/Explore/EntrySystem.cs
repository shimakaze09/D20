public partial class Data
{
    public string entryName;
}

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
        if (!string.IsNullOrEmpty(name))
            IEncounterSystem.Resolve().SetName(string.Empty);
    }

    public string GetName()
    {
        return IDataSystem.Resolve().Data.entryName;
    }
}
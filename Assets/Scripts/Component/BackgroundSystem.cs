public partial class Data
{
    public CoreDictionary<Entity, string> background = new();
}

public interface IBackgroundSystem : IDependency<IBackgroundSystem>, IEntityTableSystem<string>
{
}

public class BackgroundSystem : EntityTableSystem<string>, IBackgroundSystem
{
    public override CoreDictionary<Entity, string> Table => IDataSystem.Resolve().Data.background;
}

public partial struct Entity
{
    public string Background
    {
        get => IBackgroundSystem.Resolve().Get(this);
        set => IBackgroundSystem.Resolve().Set(this, value);
    }
}
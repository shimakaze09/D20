public partial class Data
{
    public CoreDictionary<Entity, int> level = new();
}

public interface ILevelSystem : IDependency<ILevelSystem>,
    IEntityTableSystem<int>
{
}

public class LevelSystem : EntityTableSystem<int>, ILevelSystem
{
    public override CoreDictionary<Entity, int> Table =>
        IDataSystem.Resolve().Data.level;
}

public partial struct Entity
{
    public int Level
    {
        get => ILevelSystem.Resolve().Get(this);
        set => ILevelSystem.Resolve().Set(this, value);
    }
}
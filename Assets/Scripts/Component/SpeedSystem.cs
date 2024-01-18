public partial class Data
{
    public CoreDictionary<Entity, int> speed = new();
}

public interface ISpeedSystem : IDependency<ISpeedSystem>, IEntityTableSystem<int>
{
}

public class SpeedSystem : EntityTableSystem<int>, ISpeedSystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.speed;
}

public partial struct Entity
{
    public int Speed
    {
        get => ISpeedSystem.Resolve().Get(this);
        set => ISpeedSystem.Resolve().Set(this, value);
    }
}
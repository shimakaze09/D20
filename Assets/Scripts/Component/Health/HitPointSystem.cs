public partial class Data
{
    public CoreDictionary<Entity, int> hitPoints = new();
}

public interface IHitPointSystem : IDependency<IHitPointSystem>, IEntityTableSystem<int>
{
}

public class HitPointSystem : EntityTableSystem<int>, IHitPointSystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.hitPoints;
}

public partial struct Entity
{
    public int HitPoints
    {
        get => IHitPointSystem.Resolve().Get(this);
        set => IHitPointSystem.Resolve().Set(this, value);
    }
}
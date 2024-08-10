public partial class Data
{
    public CoreDictionary<Entity, int> initiative = new();
}

public interface IInitiativeSystem : IDependency<IInitiativeSystem>, IEntityTableSystem<int>
{
}

public class InitiativeSystem : EntityTableSystem<int>, IInitiativeSystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.initiative;
}

public partial struct Entity
{
    public int Initiative
    {
        get => IInitiativeSystem.Resolve().Get(this);
        set => IInitiativeSystem.Resolve().Set(this, value);
    }
}
public partial class Data
{
    public CoreDictionary<Entity, Entity> primaryHand = new();
}

public interface IPrimaryHandSystem : IDependency<IPrimaryHandSystem>, IEntityTableSystem<Entity>
{
}

public class PrimaryHandSystem : EntityRelationTableSystem, IPrimaryHandSystem
{
    public override CoreDictionary<Entity, Entity> Table => IDataSystem.Resolve().Data.primaryHand;
}

public partial struct Entity
{
    public Entity PrimaryHand
    {
        get => IPrimaryHandSystem.Resolve().Get(this);
        set => IPrimaryHandSystem.Resolve().Set(this, value);
    }
}
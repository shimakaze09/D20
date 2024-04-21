public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Unique
}

public partial class Data
{
    public CoreDictionary<Entity, Rarity> rarity = new();
}

public interface IRaritySystem : IDependency<IRaritySystem>, IEntityTableSystem<Rarity>
{
}

public class RaritySystem : EntityTableSystem<Rarity>, IRaritySystem
{
    public override CoreDictionary<Entity, Rarity> Table => IDataSystem.Resolve().Data.rarity;
}

public partial struct Entity
{
    public Rarity Rarity
    {
        get => IRaritySystem.Resolve().Get(this);
        set => IRaritySystem.Resolve().Set(this, value);
    }
}
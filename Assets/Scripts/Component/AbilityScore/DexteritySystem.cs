public partial class Data
{
    public CoreDictionary<Entity, AbilityScore> dexterity = new();
}

public interface IDexteritySystem : IDependency<IDexteritySystem>,
    IEntityTableSystem<AbilityScore>
{
}

public class DexteritySystem : EntityTableSystem<AbilityScore>, IDexteritySystem
{
    public override CoreDictionary<Entity, AbilityScore> Table =>
        IDataSystem.Resolve().Data.dexterity;
}

public partial struct Entity
{
    public AbilityScore Dexterity
    {
        get => IDexteritySystem.Resolve().Get(this);
        set => IDexteritySystem.Resolve().Set(this, value);
    }
}
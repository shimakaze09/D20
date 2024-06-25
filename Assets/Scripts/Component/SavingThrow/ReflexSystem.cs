public partial class Data
{
    public CoreDictionary<Entity, int> reflex = new();
}

public interface IReflexSystem : IDependency<IReflexSystem>, IBaseSavingThrowSystem
{
}

public class ReflexSystem : BaseSavingThrowSystem, IReflexSystem
{
    protected override SavingThrow SavingThrow => SavingThrow.Reflex;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Dexterity;
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.reflex;
}

public partial struct Entity
{
    public int Reflex
    {
        get => IReflexSystem.Resolve().Get(this);
        set => IReflexSystem.Resolve().Set(this, value);
    }
}
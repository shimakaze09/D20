public partial class Data
{
    public CoreDictionary<Entity, int> will = new();
}

public interface IWillSystem : IDependency<IWillSystem>, IBaseSavingThrowSystem
{
}

public class WillSystem : BaseSavingThrowSystem, IWillSystem
{
    protected override SavingThrow SavingThrow => SavingThrow.Will;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Wisdom;
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.will;
}

public partial struct Entity
{
    public int Will
    {
        get => IWillSystem.Resolve().Get(this);
        set => IWillSystem.Resolve().Set(this, value);
    }
}
public partial class Data
{
    public CoreDictionary<Entity, int> fortitude = new();
}

public interface IFortitudeSystem : IDependency<IFortitudeSystem>, IBaseSavingThrowSystem
{
}

public class FortitudeSystem : BaseSavingThrowSystem, IFortitudeSystem
{
    protected override SavingThrow SavingThrow => SavingThrow.Fortitude;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Constitution;
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.fortitude;
}

public partial struct Entity
{
    public int Fortitude
    {
        get => IFortitudeSystem.Resolve().Get(this);
        set => IFortitudeSystem.Resolve().Set(this, value);
    }
}
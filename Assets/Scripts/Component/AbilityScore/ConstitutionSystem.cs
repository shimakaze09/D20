public partial class Data
{
    public CoreDictionary<Entity, AbilityScore> constitution = new();
}

public interface IConstitutionSystem : IDependency<IConstitutionSystem>, IEntityTableSystem<AbilityScore>
{
}

public class ConstitutionSystem : EntityTableSystem<AbilityScore>, IConstitutionSystem
{
    public override CoreDictionary<Entity, AbilityScore> Table => IDataSystem.Resolve().Data.constitution;
}

public partial struct Entity
{
    public AbilityScore Constitution
    {
        get => IConstitutionSystem.Resolve().Get(this);
        set => IConstitutionSystem.Resolve().Set(this, value);
    }
}
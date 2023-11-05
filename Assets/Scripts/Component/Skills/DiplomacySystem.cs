public partial class Data
{
    public CoreDictionary<Entity, int> diplomacy = new();
}

public interface IDiplomacySystem : IDependency<IDiplomacySystem>, IBaseSkillSystem
{
}

public class DiplomacySystem : BaseSkillSystem, IDiplomacySystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.diplomacy;
    protected override Skill Skill => Skill.Diplomacy;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Charisma;
}

public partial struct Entity
{
    public int Diplomacy
    {
        get => IDiplomacySystem.Resolve().Get(this);
        set => IDiplomacySystem.Resolve().Set(this, value);
    }
}
public partial class Data
{
    public CoreDictionary<Entity, int> stealth = new();
}

public interface IStealthSystem : IDependency<IStealthSystem>, IBaseSkillSystem
{
}

public class StealthSystem : BaseSkillSystem, IStealthSystem
{
    protected override Skill Skill => Skill.Stealth;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Dexterity;
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.stealth;
}

public partial struct Entity
{
    public int Stealth
    {
        get => IStealthSystem.Resolve().Get(this);
        set => IStealthSystem.Resolve().Set(this, value);
    }
}
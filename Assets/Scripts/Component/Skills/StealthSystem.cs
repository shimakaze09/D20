public partial class Data
{
    public CoreDictionary<Entity, int> stealth = new();
}

public interface IStealthSystem : IDependency<IStealthSystem>, IBaseSkillSystem
{
}

public class StealthSystem : BaseSkillSystem, IStealthSystem
{
    public override CoreDictionary<Entity, int> Table =>
        IDataSystem.Resolve().Data.stealth;

    protected override Skill Skill => Skill.Stealth;

    protected override AbilityScore.Attribute Attribute =>
        AbilityScore.Attribute.Dexterity;
}

public partial struct Entity
{
    public int Stealth
    {
        get => IStealthSystem.Resolve().Get(this);
        set => IStealthSystem.Resolve().Set(this, value);
    }
}
public partial class Data
{
    public CoreDictionary<Entity, int> intimidation = new();
}

public interface IIntimidationSystem : IDependency<IIntimidationSystem>, IBaseSkillSystem
{
}

public class IntimidationSystem : BaseSkillSystem, IIntimidationSystem
{
    protected override Skill Skill => Skill.Intimidation;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Charisma;
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.intimidation;
}

public partial struct Entity
{
    public int Intimidation
    {
        get => IIntimidationSystem.Resolve().Get(this);
        set => IIntimidationSystem.Resolve().Set(this, value);
    }
}
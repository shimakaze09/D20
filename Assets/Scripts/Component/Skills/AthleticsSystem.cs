public partial class Data
{
    public CoreDictionary<Entity, int> athletics = new();
}

public interface IAthleticsSystem : IDependency<IAthleticsSystem>, IBaseSkillSystem
{
}

public class AthleticsSystem : BaseSkillSystem, IAthleticsSystem
{
    protected override Skill Skill => Skill.Athletics;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Strength;
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.athletics;
}

public partial struct Entity
{
    public int Athletics
    {
        get => IAthleticsSystem.Resolve().Get(this);
        set => IAthleticsSystem.Resolve().Set(this, value);
    }
}
public partial class Data
{
    public CoreDictionary<Entity, int> survival = new();
}

public interface ISurvivalSystem : IDependency<ISurvivalSystem>, IBaseSkillSystem
{
}

public class SurvivalSystem : BaseSkillSystem, ISurvivalSystem
{
    protected override Skill Skill => Skill.Survival;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Wisdom;
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.survival;
}

public partial struct Entity
{
    public int Survival
    {
        get => ISurvivalSystem.Resolve().Get(this);
        set => ISurvivalSystem.Resolve().Set(this, value);
    }
}
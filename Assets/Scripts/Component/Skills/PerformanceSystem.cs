public partial class Data
{
    public CoreDictionary<Entity, int> performance = new();
}

public interface IPerformanceSystem : IDependency<IPerformanceSystem>, IBaseSkillSystem
{
}

public class PerformanceSystem : BaseSkillSystem, IPerformanceSystem
{
    protected override Skill Skill => Skill.Performance;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Charisma;
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.performance;
}

public partial struct Entity
{
    public int Performance
    {
        get => IPerformanceSystem.Resolve().Get(this);
        set => IPerformanceSystem.Resolve().Set(this, value);
    }
}
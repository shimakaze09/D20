public partial class Data
{
    public CoreDictionary<Entity, int> occultism = new();
}

public interface IOccultismSystem : IDependency<IOccultismSystem>, IBaseSkillSystem
{
}

public class OccultismSystem : BaseSkillSystem, IOccultismSystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.occultism;
    protected override Skill Skill => Skill.Occultism;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Intelligence;
}

public partial struct Entity
{
    public int Occultism
    {
        get => IOccultismSystem.Resolve().Get(this);
        set => IOccultismSystem.Resolve().Set(this, value);
    }
}
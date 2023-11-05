public partial class Data
{
    public CoreDictionary<Entity, int> nature = new();
}

public interface INatureSystem : IDependency<INatureSystem>, IBaseSkillSystem
{
}

public class NatureSystem : BaseSkillSystem, INatureSystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.nature;
    protected override Skill Skill => Skill.Nature;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Wisdom;
}

public partial struct Entity
{
    public int Nature
    {
        get => INatureSystem.Resolve().Get(this);
        set => INatureSystem.Resolve().Set(this, value);
    }
}
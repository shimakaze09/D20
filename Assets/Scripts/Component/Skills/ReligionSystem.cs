public partial class Data
{
    public CoreDictionary<Entity, int> religion = new();
}

public interface IReligionSystem : IDependency<IReligionSystem>, IBaseSkillSystem
{
}

public class ReligionSystem : BaseSkillSystem, IReligionSystem
{
    protected override Skill Skill => Skill.Religion;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Wisdom;
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.religion;
}

public partial struct Entity
{
    public int Religion
    {
        get => IReligionSystem.Resolve().Get(this);
        set => IReligionSystem.Resolve().Set(this, value);
    }
}
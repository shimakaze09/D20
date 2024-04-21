public partial class Data
{
    public CoreDictionary<Entity, int> acrobatics = new();
}

public interface IAcrobaticsSystem : IDependency<IAcrobaticsSystem>, IBaseSkillSystem
{
}

public class AcrobaticsSystem : BaseSkillSystem, IAcrobaticsSystem
{
    protected override Skill Skill => Skill.Acrobatics;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Dexterity;
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.acrobatics;
}

public partial struct Entity
{
    public int Acrobatics
    {
        get => IAcrobaticsSystem.Resolve().Get(this);
        set => IAcrobaticsSystem.Resolve().Set(this, value);
    }
}
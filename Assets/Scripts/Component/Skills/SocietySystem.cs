public partial class Data
{
    public CoreDictionary<Entity, int> society = new CoreDictionary<Entity, int>();
}

public interface ISocietySystem : IDependency<ISocietySystem>, IBaseSkillSystem
{

}

public class SocietySystem : BaseSkillSystem, ISocietySystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.society;
    protected override Skill Skill => Skill.Society;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Intelligence;
}

public partial struct Entity
{
    public int Society
    {
        get => ISocietySystem.Resolve().Get(this);
        set => ISocietySystem.Resolve().Set(this, value);
    }
}
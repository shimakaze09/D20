public partial class Data
{
    public CoreDictionary<Entity, int> thievery = new();
}

public interface IThieverySystem : IDependency<IThieverySystem>, IBaseSkillSystem
{
}

public class ThieverySystem : BaseSkillSystem, IThieverySystem
{
    protected override Skill Skill => Skill.Thievery;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Dexterity;
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.thievery;
}

public partial struct Entity
{
    public int Thievery
    {
        get => IThieverySystem.Resolve().Get(this);
        set => IThieverySystem.Resolve().Set(this, value);
    }
}
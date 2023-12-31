public partial class Data
{
    public CoreDictionary<Entity, int> arcana = new();
}

public interface IArcanaSystem : IDependency<IArcanaSystem>, IBaseSkillSystem
{
}

public class ArcanaSystem : BaseSkillSystem, IArcanaSystem
{
    protected override Skill Skill => Skill.Arcana;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Intelligence;
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.arcana;
}

public partial struct Entity
{
    public int Arcana
    {
        get => IArcanaSystem.Resolve().Get(this);
        set => IArcanaSystem.Resolve().Set(this, value);
    }
}
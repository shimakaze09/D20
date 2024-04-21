public partial class Data
{
    public CoreDictionary<Entity, int> lore = new();
}

public interface ILoreSystem : IDependency<ILoreSystem>, IBaseSkillSystem
{
}

public class LoreSystem : BaseSkillSystem, ILoreSystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.lore;
    protected override Skill Skill => Skill.Lore;
    protected override AbilityScore.Attribute Attribute => AbilityScore.Attribute.Intelligence;
}

public partial struct Entity
{
    public int Lore
    {
        get => ILoreSystem.Resolve().Get(this);
        set => ILoreSystem.Resolve().Set(this, value);
    }
}
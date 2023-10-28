public partial class Data
{
    public CoreDictionary<Entity, int> medicine = new();
}

public interface IMedicineSystem : IDependency<IMedicineSystem>,
    IBaseSkillSystem
{
}

public class MedicineSystem : BaseSkillSystem, IMedicineSystem
{
    public override CoreDictionary<Entity, int> Table =>
        IDataSystem.Resolve().Data.medicine;

    protected override Skill Skill => Skill.Medicine;

    protected override AbilityScore.Attribute Attribute =>
        AbilityScore.Attribute.Wisdom;
}

public partial struct Entity
{
    public int Medicine
    {
        get => IMedicineSystem.Resolve().Get(this);
        set => IMedicineSystem.Resolve().Set(this, value);
    }
}
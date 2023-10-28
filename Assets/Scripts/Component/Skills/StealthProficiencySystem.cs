public partial class Data
{
    public CoreDictionary<Entity, Proficiency> stealthProficiency = new();
}

public interface IStealthProficiencySystem :
    IDependency<IStealthProficiencySystem>, IEntityTableSystem<Proficiency>
{
}

public class StealthProficiencySystem : EntityTableSystem<Proficiency>,
    IStealthProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table =>
        IDataSystem.Resolve().Data.stealthProficiency;
}
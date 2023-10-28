public partial class Data
{
    public CoreDictionary<Entity, Proficiency> performanceProficiency = new();
}

public interface IPerformanceProficiencySystem :
    IDependency<IPerformanceProficiencySystem>, IEntityTableSystem<Proficiency>
{
}

public class PerformanceProficiencySystem : EntityTableSystem<Proficiency>,
    IPerformanceProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table =>
        IDataSystem.Resolve().Data.performanceProficiency;
}
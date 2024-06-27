public partial class Data
{
    public CoreDictionary<Entity, Proficiency> perceptionProficiency = new();
}

public interface IPerceptionProficiencySystem : IDependency<IPerceptionProficiencySystem>,
    IEntityTableSystem<Proficiency>
{
}

public class PerceptionProficiencySystem : EntityTableSystem<Proficiency>, IPerceptionProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.perceptionProficiency;
}
public partial class Data
{
    public CoreDictionary<Entity, Proficiency> deceptionProficiency = new();
}

public interface IDeceptionProficiencySystem : IDependency<IDeceptionProficiencySystem>, IEntityTableSystem<Proficiency>
{
}

public class DeceptionProficiencySystem : EntityTableSystem<Proficiency>, IDeceptionProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.deceptionProficiency;
}
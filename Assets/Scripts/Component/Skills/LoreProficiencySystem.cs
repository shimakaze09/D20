public partial class Data
{
    public CoreDictionary<Entity, Proficiency> loreProficiency = new();
}

public interface ILoreProficiencySystem : IDependency<ILoreProficiencySystem>, IEntityTableSystem<Proficiency>
{
}

[Dependency(typeof(ILoreProficiencySystem))]
public class LoreProficiencySystem : EntityTableSystem<Proficiency>, ILoreProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.loreProficiency;
}
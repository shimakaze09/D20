public partial class Data
{
    public CoreDictionary<Entity, Proficiency> diplomacyProficiency = new();
}

public interface IDiplomacyProficiencySystem : IDependency<IDiplomacyProficiencySystem>, IEntityTableSystem<Proficiency>
{
}

[Dependency(typeof(IDiplomacyProficiencySystem))]
public class DiplomacyProficiencySystem : EntityTableSystem<Proficiency>, IDiplomacyProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.diplomacyProficiency;
}
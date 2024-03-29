public partial class Data
{
    public CoreDictionary<Entity, Proficiency> societyProficiency = new();
}

public interface ISocietyProficiencySystem : IDependency<ISocietyProficiencySystem>, IEntityTableSystem<Proficiency>
{
}

public class SocietyProficiencySystem : EntityTableSystem<Proficiency>, ISocietyProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.societyProficiency;
}
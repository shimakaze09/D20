public partial class Data
{
    public CoreDictionary<Entity, Proficiency> athleticsProficiency = new();
}

public interface IAthleticsProficiencySystem : IDependency<IAthleticsProficiencySystem>, IEntityTableSystem<Proficiency>
{
}

[Dependency(typeof(IAthleticsProficiencySystem))]
public class AthleticsProficiencySystem : EntityTableSystem<Proficiency>, IAthleticsProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.athleticsProficiency;
}
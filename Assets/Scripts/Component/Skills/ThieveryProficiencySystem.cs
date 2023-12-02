public partial class Data
{
    public CoreDictionary<Entity, Proficiency> thieveryProficiency = new();
}

public interface IThieveryProficiencySystem : IDependency<IThieveryProficiencySystem>, IEntityTableSystem<Proficiency>
{
}

public class ThieveryProficiencySystem : EntityTableSystem<Proficiency>, IThieveryProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.thieveryProficiency;
}
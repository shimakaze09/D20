public partial class Data
{
    public CoreDictionary<Entity, Proficiency> fortitudeProficiency = new();
}

public interface IFortitudeProficiencySystem : IDependency<IFortitudeProficiencySystem>, IEntityTableSystem<Proficiency>
{
}

public class FortitudeProficiencySystem : EntityTableSystem<Proficiency>, IFortitudeProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.fortitudeProficiency;
}
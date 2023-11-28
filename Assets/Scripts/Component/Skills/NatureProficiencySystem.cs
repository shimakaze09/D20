public partial class Data
{
    public CoreDictionary<Entity, Proficiency> natureProficiency = new();
}

public interface INatureProficiencySystem : IDependency<INatureProficiencySystem>, IEntityTableSystem<Proficiency>
{

}

public class NatureProficiencySystem : EntityTableSystem<Proficiency>, INatureProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.natureProficiency;
}
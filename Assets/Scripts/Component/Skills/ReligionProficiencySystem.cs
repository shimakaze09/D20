public partial class Data
{
    public CoreDictionary<Entity, Proficiency> religionProficiency = new();
}

public interface IReligionProficiencySystem : IDependency<IReligionProficiencySystem>, IEntityTableSystem<Proficiency>
{

}

public class ReligionProficiencySystem : EntityTableSystem<Proficiency>, IReligionProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.religionProficiency;
}
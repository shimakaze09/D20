public partial class Data
{
    public CoreDictionary<Entity, Proficiency> acrobaticsProficiency = new();
}

public interface IAcrobaticsProficiencySystem : IDependency<IAcrobaticsProficiencySystem>, IEntityTableSystem<Proficiency>
{

}

public class AcrobaticsProficiencySystem : EntityTableSystem<Proficiency>, IAcrobaticsProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.acrobaticsProficiency;
}
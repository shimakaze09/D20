public partial class Data
{
    public CoreDictionary<Entity, Proficiency> occultismProficiency = new();
}

public interface IOccultismProficiencySystem :
    IDependency<IOccultismProficiencySystem>, IEntityTableSystem<Proficiency>
{
}

public class OccultismProficiencySystem : EntityTableSystem<Proficiency>,
    IOccultismProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table =>
        IDataSystem.Resolve().Data.occultismProficiency;
}
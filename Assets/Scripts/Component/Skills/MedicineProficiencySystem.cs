public partial class Data
{
    public CoreDictionary<Entity, Proficiency> medicineProficiency = new();
}

public interface IMedicineProficiencySystem : IDependency<IMedicineProficiencySystem>, IEntityTableSystem<Proficiency>
{
}

public class MedicineProficiencySystem : EntityTableSystem<Proficiency>, IMedicineProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.medicineProficiency;
}
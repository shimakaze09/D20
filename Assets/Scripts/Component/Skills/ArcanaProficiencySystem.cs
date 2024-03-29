public partial class Data
{
    public CoreDictionary<Entity, Proficiency> arcanaProficiency = new();
}

public interface IArcanaProficiencySystem : IDependency<IArcanaProficiencySystem>, IEntityTableSystem<Proficiency>
{
}

public class ArcanaProficiencySystem : EntityTableSystem<Proficiency>, IArcanaProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.arcanaProficiency;
}
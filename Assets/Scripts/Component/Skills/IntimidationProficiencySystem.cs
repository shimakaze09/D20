public partial class Data
{
    public CoreDictionary<Entity, Proficiency> intimidationProficiency = new();
}

public interface IIntimidationProficiencySystem : IDependency<IIntimidationProficiencySystem>,
    IEntityTableSystem<Proficiency>
{
}

public class IntimidationProficiencySystem : EntityTableSystem<Proficiency>, IIntimidationProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.intimidationProficiency;
}
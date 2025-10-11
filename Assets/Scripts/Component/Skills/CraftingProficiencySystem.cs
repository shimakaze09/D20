public partial class Data
{
    public CoreDictionary<Entity, Proficiency> craftingProficiency = new();
}

public interface ICraftingProficiencySystem : IDependency<ICraftingProficiencySystem>, IEntityTableSystem<Proficiency>
{
}

[Dependency(typeof(ICraftingProficiencySystem))]
public class CraftingProficiencySystem : EntityTableSystem<Proficiency>, ICraftingProficiencySystem
{
    public override CoreDictionary<Entity, Proficiency> Table => IDataSystem.Resolve().Data.craftingProficiency;
}
public partial class Data
{
    public CoreDictionary<Entity, int> armorClass = new();
}

public interface IArmorClassSystem : IDependency<IArmorClassSystem>, IEntityTableSystem<int>
{

}

public class ArmorClassSystem : EntityTableSystem<int>, IArmorClassSystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.armorClass;
}

public partial struct Entity
{
    public int ArmorClass
    {
        get => IArmorClassSystem.Resolve().Get(this);
        set => IArmorClassSystem.Resolve().Set(this, value);

    }
}
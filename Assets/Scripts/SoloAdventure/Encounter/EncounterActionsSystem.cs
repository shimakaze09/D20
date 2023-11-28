using System.Collections.Generic;

[System.Serializable]
public struct EncounterActions
{
    public List<string> names;

    public EncounterActions(List<string> names)
    {
        this.names = names;
    }
}

public partial class Data
{
    public CoreDictionary<Entity, EncounterActions> encounterActions = new();
}

public interface IEncounterActionsSystem : IDependency<IEncounterActionsSystem>, IEntityTableSystem<EncounterActions>
{

}

public class EncounterActionsSystem : EntityTableSystem<EncounterActions>, IEncounterActionsSystem
{
    public override CoreDictionary<Entity, EncounterActions> Table => IDataSystem.Resolve().Data.encounterActions;
}

public partial struct Entity
{
    public EncounterActions EncounterActions
    {
        get => IEncounterActionsSystem.Resolve().Get(this);
        set => IEncounterActionsSystem.Resolve().Set(this, value);

    }
}
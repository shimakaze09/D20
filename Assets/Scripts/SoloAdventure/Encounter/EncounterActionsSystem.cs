using System.Collections.Generic;

public interface IEncounterActionsSystem : IDependency<IEncounterActionsSystem>,
    IEntityTableSystem<List<string>>
{
}

public class EncounterActionsSystem : EntityTableSystem<List<string>>,
    IEncounterActionsSystem
{
    public override CoreDictionary<Entity, List<string>> Table => _table;
    private CoreDictionary<Entity, List<string>> _table = new();
}

public partial struct Entity
{
    public List<string> EncounterActions
    {
        get => IEncounterActionsSystem.Resolve().Get(this);
        set => IEncounterActionsSystem.Resolve().Set(this, value);
    }
}
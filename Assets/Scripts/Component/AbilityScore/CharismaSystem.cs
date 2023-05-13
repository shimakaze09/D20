﻿public partial class Data
{
    public CoreDictionary<Entity, AbilityScore> Charisma = new();
}

public interface ICharismaSystem : IDependency<ICharismaSystem>, IEntityTableSystem<AbilityScore>
{
}

public class CharismaSystem : EntityTableSystem<AbilityScore>, IWisdomSystem
{
    public override CoreDictionary<Entity, AbilityScore> Table => IDataSystem.Resolve().Data.Charisma;
}

public partial struct Entity
{
    public AbilityScore Charisma
    {
        get => ICharismaSystem.Resolve().Get(this);
        set => ICharismaSystem.Resolve().Set(this, value);
    }
}
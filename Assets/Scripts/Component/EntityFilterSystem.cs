using System;
using System.Collections.Generic;

[Flags]
public enum EntityFilter
{
    None = 0,
    Living = 1 << 0,
    Dying = 1 << 1,
    Dead = 1 << 2,
    Opponent = 1 << 3,
    Ally = 1 << 4
}

public interface IEntityFilterSystem : IDependency<IEntityFilterSystem>
{
    List<Entity> Apply(EntityFilter filter, Entity entity, List<Entity> entities);
}

public class EntityFilterSystem : IEntityFilterSystem
{
    public List<Entity> Apply(EntityFilter filter, Entity entity, List<Entity> entities)
    {
        var result = new List<Entity>();
        foreach (var candidate in entities)
        {
            if (filter.HasFlag(EntityFilter.Living) && candidate.HitPoints <= 0)
                continue;
            if (filter.HasFlag(EntityFilter.Dying) && candidate.Dying <= 0)
                continue;
            // TODO: Dead
            if (filter.HasFlag(EntityFilter.Opponent) && candidate.Party == entity.Party)
                continue;
            if (filter.HasFlag(EntityFilter.Ally) && candidate.Party != entity.Party)
                continue;
            result.Add(candidate);
        }

        return result;
    }
}

public static class EntityFilterExtensions
{
    public static List<Entity> Apply(this EntityFilter filter, Entity entity, List<Entity> entities)
    {
        return IEntityFilterSystem.Resolve().Apply(filter, entity, entities);
    }
}
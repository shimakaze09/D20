#region

using System.Collections.Generic;

#endregion

public interface IRoundSystem : IDependency<IRoundSystem>
{
    bool IsComplete { get; }

    void Begin(List<Entity> entities);
    Entity Next();
}

public class RoundSystem : IRoundSystem
{
    private List<Entity> turnOrder;

    public bool IsComplete => turnOrder.Count == 0;

    public void Begin(List<Entity> entities)
    {
        turnOrder = entities;
    }

    public Entity Next()
    {
        var result = turnOrder[0];
        turnOrder.RemoveAt(0);
        return result;
    }
}
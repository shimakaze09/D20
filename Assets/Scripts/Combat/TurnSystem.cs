#region

using System.Collections.Generic;

#endregion

public interface ITurnSystem : IDependency<ITurnSystem>
{
    Entity Current { get; }
    int ActionsRemaining { get; }
    int AttackCount { get; }
    bool IsComplete { get; }
    List<Entity> InReach { get; set; }

    void Begin(Entity entity);
    void TakeAction(int actionCost, bool isAttack);
}

public class TurnSystem : ITurnSystem
{
    public Entity Current { get; private set; }

    public int ActionsRemaining { get; private set; }

    public int AttackCount { get; private set; }

    public bool IsComplete => ActionsRemaining == 0;

    public List<Entity> InReach { get; set; }

    public void Begin(Entity entity)
    {
        Current = entity;
        ActionsRemaining = 3;
        AttackCount = 0;
    }

    public void TakeAction(int actionCost, bool isAttack)
    {
        ActionsRemaining -= actionCost;
        if (isAttack) AttackCount++;
    }
}
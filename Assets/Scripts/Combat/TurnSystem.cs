using System.Collections.Generic;

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
    public Entity Current => current;
    private Entity current;

    public int ActionsRemaining => actionsRemaining;
    private int actionsRemaining;

    public int AttackCount => attackCount;
    private int attackCount;

    public bool IsComplete => actionsRemaining == 0;

    public List<Entity> InReach { get; set; }

    public void Begin(Entity entity)
    {
        current = entity;
        actionsRemaining = 3;
        attackCount = 0;
    }

    public void TakeAction(int actionCost, bool isAttack)
    {
        actionsRemaining -= actionCost;
        if (isAttack) attackCount++;
    }
}
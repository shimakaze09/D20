public interface ITurnSystem : IDependency<ITurnSystem>
{
    bool IsComplete { get; }

    void Begin(Entity entity);
}

public class TurnSystem : ITurnSystem
{
    public bool IsComplete
    {
        get
        {
            // TEMP
            var result = isComplete;
            isComplete = true;
            return result;
        }
    }

    private bool isComplete;

    public void Begin(Entity entity)
    {
        isComplete = false;
    }
}
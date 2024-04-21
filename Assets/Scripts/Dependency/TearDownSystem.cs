using System;
using System.Collections.Generic;

public interface ITearDownSystem : IDependency<ITearDownSystem>
{
    void TearDown();
    void Add(Action action);
    void Remove(Action action);
}

public class TearDownSystem : ITearDownSystem
{
    private readonly List<Action> actions = new();

    public void TearDown()
    {
        foreach (var action in actions)
            action();
    }

    public void Add(Action action)
    {
        actions.Add(action);
    }

    public void Remove(Action action)
    {
        actions.Remove(action);
    }
}
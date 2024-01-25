using System;
using System.Collections.Generic;

public interface ISetUpSystem : IDependency<ISetUpSystem>
{
    void SetUp();
    void Add(Action action);
    void Remove(Action action);
}

public class SetUpSystem : ISetUpSystem
{
    private readonly List<Action> actions = new();

    public void SetUp()
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
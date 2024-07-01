#region

using UnityEngine;

#endregion

public partial class Data
{
    public CoreDictionary<Entity, int> perception = new();
}

public interface IPerceptionSystem : IDependency<IPerceptionSystem>, IEntityTableSystem<int>
{
    void Setup(Entity entity);
}

public class PerceptionSystem : EntityTableSystem<int>, IPerceptionSystem
{
    public override CoreDictionary<Entity, int> Table => IDataSystem.Resolve().Data.perception;

    public void Setup(Entity entity)
    {
        Table[entity] = Calculate(entity);
    }

    private int Calculate(Entity entity)
    {
        var result = entity[AbilityScore.Attribute.Wisdom].Modifier;
        var proficiency = IPerceptionProficiencySystem.Resolve().Get(entity);
        if (proficiency != Proficiency.Untrained)
            result += (int)proficiency * 2 + entity.Level;
        Debug.Log($"Proficiency: {result}");
        return result;
    }
}

public partial struct Entity
{
    public int Perception
    {
        get => IPerceptionSystem.Resolve().Get(this);
        set => IPerceptionSystem.Resolve().Set(this, value);
    }
}
public interface IBaseSavingThrowSystem : IEntityTableSystem<int>
{
    void Setup(Entity entity);
}

public abstract class BaseSavingThrowSystem : EntityTableSystem<int>, IBaseSavingThrowSystem
{
    protected abstract SavingThrow SavingThrow { get; }
    protected abstract AbilityScore.Attribute Attribute { get; }

    public virtual void Setup(Entity entity)
    {
        Table[entity] = Calculate(entity);
    }

    protected virtual int Calculate(Entity entity)
    {
        var result = entity[Attribute].Modifier;
        var proficiency = ISavingThrowProficiencySystem.Resolve().Get(entity, SavingThrow);
        if (proficiency != Proficiency.Untrained)
            result += (int)proficiency * 2 + entity.Level;
        return result;
    }
}
using System.Collections.Generic;

public partial class Data
{
    public CoreSet<Entity> entities = new();
}

public interface IEntitySystem : IDependency<IEntitySystem>
{
    Entity Create();
    void Destroy(Entity entity);
}

public class EntitySystem : IEntitySystem
{
    private Data Data => IDataSystem.Resolve().Data;
    private IRandomNumberGenerator RNG => IRandomNumberGenerator.Resolve();

    public Entity Create()
    {
        Entity result;
        do
        {
            result = new Entity(RNG.Range(int.MinValue, int.MaxValue));
        } while (result.id == 0 || Data.entities.Contains(result));

        Data.entities.Add(result);
        return result;
    }

    public void Destroy(Entity entity)
    {
        Data.entities.Remove(entity);
    }
}
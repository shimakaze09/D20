public abstract class EntityRelationTableSystem : EntityTableSystem<Entity>
{
    protected override void OnEntityDestroyed(Entity entity)
    {
        Entity target;
        if (TryGetValue(entity, out target)) IEntitySystem.Resolve().Destroy(target);
        base.OnEntityDestroyed(entity);
    }
}
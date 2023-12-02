using UnityEngine;

public interface IPhysicsSystem : IDependency<IPhysicsSystem>
{
    Entity? OverlapPoint(Point point, int layerMask);
}

public class PhysicsSystem : IPhysicsSystem
{
    private const int maxResultCount = 10;
    private Collider2D[] results = new Collider2D[maxResultCount];

    public Entity? OverlapPoint(Point point, int layerMask)
    {
        var pos = new Vector2(point.x + 0.5f, point.y + 0.5f);
        var resultCount = Physics2D.OverlapPointNonAlloc(pos, results, layerMask);
        for (var i = 0; i < Mathf.Min(resultCount, maxResultCount); ++i)
        {
            var entityView = results[i].GetComponent<EntityView>();
            if (entityView)
                return entityView.entity;
        }

        return null;
    }
}
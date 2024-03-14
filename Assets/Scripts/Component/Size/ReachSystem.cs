using System.Collections.Generic;
using UnityEngine;

public enum Reach
{
    Tall,
    Long
}

public partial class Data
{
    public CoreDictionary<Entity, Reach> reach = new();
}

public interface IReachSystem : IDependency<IReachSystem>, IEntityTableSystem<Reach>
{
    int ReachInFeet(Size size, Reach reach);
    int ReachInTiles(Size size, Reach reach);
    List<Point> ReachTileOffsets(Size size, Reach reach);
    List<Point> ReachTiles(Size size, Reach reach, Point position);
    List<Entity> EntitiesInReach(Entity entity);
}

public class ReachSystem : EntityTableSystem<Reach>, IReachSystem
{
    private const int tileSize = 5;
    public override CoreDictionary<Entity, Reach> Table => IDataSystem.Resolve().Data.reach;

    public int ReachInFeet(Size size, Reach reach)
    {
        switch (size)
        {
            case Size.Tiny:
                return 0;
            case Size.Small:
            case Size.Medium:
                return 5;
            case Size.Large:
                return reach == Reach.Tall ? 10 : 5;
            case Size.Huge:
                return reach == Reach.Tall ? 15 : 10;
            default: //  case Size.Gargantuan:
                return reach == Reach.Tall ? 20 : 15;
        }
    }

    public int ReachInTiles(Size size, Reach reach)
    {
        var range = ReachInFeet(size, reach);
        return range / tileSize;
    }

    public List<Point> ReachTileOffsets(Size size, Reach reach)
    {
        return ReachTiles(size, reach, new Point(0, 0));
    }

    public List<Point> ReachTiles(Size size, Reach reach, Point position)
    {
        var result = new List<Point>();
        var space = ISpaceSystem.Resolve().SpaceInTiles(size);
        var range = ReachInTiles(size, reach);
        for (var y = -range; y < space + range; ++y)
        for (var x = -range; x < space + range; ++x)
        {
            var delta = int.MaxValue;
            if (x >= 0 && x < space)
            {
                delta = y < 0 ? Mathf.Abs(y) : y - space;
            }
            else if (y >= 0 && y < space)
            {
                delta = x < 0 ? Mathf.Abs(x) : x - space;
            }
            else
            {
                var dX = x < 0 ? Mathf.Abs(x) : x - space + 1;
                var dY = y < 0 ? Mathf.Abs(y) : y - space + 1;

                var max = Mathf.Max(dX, dY);
                var min = Mathf.Min(dX, dY);

                delta = max + min / 2;
            }

            if (delta <= range)
                result.Add(new Point(x, y) + position);
        }

        return result;
    }

    public List<Entity> EntitiesInReach(Entity entity)
    {
        var result = new List<Entity>();

        var sizeSystem = ISizeSystem.Resolve();
        var spaceSystem = ISpaceSystem.Resolve();

        var reachablePositions = new HashSet<Point>(ReachTiles(entity.Size, entity.Reach, entity.Position));

        var candidates = new HashSet<Entity>(sizeSystem.Table.Keys);
        var entitiesWithPosition = new HashSet<Entity>(IPositionSystem.Resolve().Table.Keys);
        candidates.IntersectWith(entitiesWithPosition);

        foreach (var candidate in candidates)
        {
            var candidateSpace = spaceSystem.SpaceTiles(candidate.Size, candidate.Position);
            if (reachablePositions.Overlaps(candidateSpace)) result.Add(candidate);
        }

        return result;
    }
}

public partial struct Entity
{
    public Reach Reach
    {
        get => IReachSystem.Resolve().Get(this);
        set => IReachSystem.Resolve().Set(this, value);
    }
}
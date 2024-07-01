#region

using System.Collections.Generic;

#endregion

public interface ISpaceSystem : IDependency<ISpaceSystem>
{
    int SpaceInFeet(Size size);
    int SpaceInTiles(Size size);
    List<Point> SpaceTileOffsets(Size size);
    List<Point> SpaceTiles(Size size, Point position);
    HashSet<Point> OccupiedSpaces(IEnumerable<Entity> entities);
    void AddOccupiedSpaces(Entity entity, HashSet<Point> set);
    List<Point> AdjacentSpaces(Entity entity, Entity target);
}

public class SpaceSystem : ISpaceSystem
{
    private const int tileSize = 5;

    public int SpaceInFeet(Size size)
    {
        switch (size)
        {
            case Size.Large: return 10;
            case Size.Huge: return 15;
            case Size.Gargantuan: return 20;
            default: return 5;
        }
    }

    public int SpaceInTiles(Size size)
    {
        var space = SpaceInFeet(size);
        return space / tileSize;
    }

    public List<Point> SpaceTileOffsets(Size size)
    {
        return SpaceTiles(size, new Point(0, 0));
    }

    public List<Point> SpaceTiles(Size size, Point position)
    {
        var space = SpaceInTiles(size);
        var result = new List<Point>();
        for (var y = 0; y < space; ++y)
        for (var x = 0; x < space; ++x)
            result.Add(new Point(x, y) + position);
        return result;
    }

    public HashSet<Point> OccupiedSpaces(IEnumerable<Entity> entities)
    {
        var result = new HashSet<Point>();
        foreach (var entity in entities) AddOccupiedSpaces(entity, result);
        return result;
    }

    public void AddOccupiedSpaces(Entity entity, HashSet<Point> set)
    {
        var tileSpace = entity.Size.ToTiles();
        for (var y = 0; y < tileSpace; ++y)
        for (var x = 0; x < tileSpace; ++x)
        {
            var pos = entity.Position + new Point(x, y);
            set.Add(pos);
        }
    }

    public List<Point> AdjacentSpaces(Entity entity, Entity target)
    {
        var entitySpace = ISpaceSystem.Resolve().SpaceInTiles(entity.Size);
        var targetSpace = ISpaceSystem.Resolve().SpaceInTiles(target.Size);

        var xStart = target.Position.x - entitySpace;
        var xEnd = target.Position.x + targetSpace;
        var yStart = target.Position.y - entitySpace;
        var yEnd = target.Position.y + targetSpace;

        var result = new List<Point>();
        for (var y = yStart; y <= yEnd; ++y)
        for (var x = xStart; x <= xEnd; ++x)
            if (x == xStart || x == xEnd || y == yStart || y == yEnd)
                result.Add(new Point(x, y));
        return result;
    }
}

public static class SpaceSizeExtensions
{
    public static int ToTiles(this Size size)
    {
        return ISpaceSystem.Resolve().SpaceInTiles(size);
    }
}
using System.Collections.Generic;

public interface ISpaceSystem : IDependency<ISpaceSystem>
{
    int SpaceInFeet(Size size);
    int SpaceInTiles(Size size);
    List<Point> SpaceTileOffsets(Size size);
    List<Point> SpaceTiles(Size size, Point position);
}

public class SpaceSystem : ISpaceSystem
{
    private const int tileSize = 5;

    public int SpaceInFeet(Size size)
    {
        return size switch
        {
            Size.Large => 10,
            Size.Huge => 15,
            Size.Gargantuan => 20,
            _ => 5
        };
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
}
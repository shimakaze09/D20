using System.Collections.Generic;

public struct LandTraverser : ITraverser
{
    private const int landTile = 1;
    private const int hillTile = 2;

    private readonly HashSet<Point> passable;
    private readonly HashSet<Point> block;

    private readonly IBoardSystem system;

    public LandTraverser(HashSet<Point> passable, HashSet<Point> block)
    {
        this.passable = passable;
        this.block = block;
        system = IBoardSystem.Resolve();
    }

    public bool TryMove(Point fromPoint, Point toPoint, Size size, out int cost, out Traversal traversal)
    {
        if (size.ToTiles() > 1)
            traversal = SizeTraversal(size, toPoint);
        else
            traversal = SingleTraversal(toPoint);

        cost = int.MaxValue;
        if (traversal != Traversal.OffBoard)
        {
            var type = system.GetTileType(toPoint);
            cost = type == landTile ? 5 : 10;
            return true;
        }

        return false;
    }

    private Traversal SingleTraversal(Point point)
    {
        if (!system.IsPointOnBoard(point))
            return Traversal.OffBoard;
        if (block != null && block.Contains(point))
            return Traversal.Block;
        var type = system.GetTileType(point);
        if (!(type == landTile || type == hillTile))
            return Traversal.Block;
        if (passable != null && passable.Contains(point))
            return Traversal.Pass;
        return Traversal.Open;
    }

    private Traversal SizeTraversal(Size size, Point point)
    {
        var result = Traversal.Open;
        var range = size.ToTiles();
        for (var y = point.y; y < point.y + range; ++y)
        for (var x = point.x; x < point.x + range; ++x)
        {
            var check = SingleTraversal(new Point(x, y));
            result = (int)check > (int)result ? check : result;
        }

        return result;
    }
}
using System.Collections.Generic;

public interface ITraverser
{
    bool TryMove(Point fromPoint, Point toPoint, Size size, out int cost, out Traversal traversal);
}

public interface IPathfindingSystem : IDependency<IPathfindingSystem>
{
    IPathMap Map(Point start, int range, Size size, ITraverser traverser);
}

public class PathfindingSystem : IPathfindingSystem
{
    private Point[] offsets = new Point[]
    {
        new(0, 1),
        new(1, 0),
        new(0, -1),
        new(-1, 0),
        new(1, 1),
        new(1, -1),
        new(-1, -1),
        new(-1, 1)
    };

    public IPathMap Map(Point start, int range, Size size, ITraverser traverser)
    {
        var checkNow = new List<Point>();
        var checkNext = new HashSet<Point>();
        var map = new Dictionary<Point, PathNode>();
        map[start] = new PathNode(start, 0, false, null, Traversal.Open);
        checkNow.Add(start);

        while (checkNow.Count > 0)
        {
            foreach (var point in checkNow)
            {
                var node = map[point];
                foreach (var offset in offsets)
                {
                    var nextPoint = point + offset;

                    int moveCost;
                    Traversal traversal;
                    if (!traverser.TryMove(point, nextPoint, size, out moveCost, out traversal))
                        continue;

                    var isDiagonal = offset.x != 0 && offset.y != 0;
                    var diagonalPenalty = isDiagonal && node.diagonalActive;
                    var diagonalActive = isDiagonal ? !node.diagonalActive : node.diagonalActive;
                    if (diagonalPenalty)
                        moveCost += 5;

                    moveCost += node.moveCost;
                    if (moveCost > range)
                        continue;

                    if (!map.ContainsKey(nextPoint))
                    {
                        map[nextPoint] = new PathNode(nextPoint, moveCost, diagonalActive, node, traversal);
                        if (traversal != Traversal.Block)
                            checkNext.Add(nextPoint);
                    }
                    else if (moveCost < map[nextPoint].moveCost)
                    {
                        map[nextPoint].moveCost = moveCost;
                        map[nextPoint].diagonalActive = diagonalActive;
                        map[nextPoint].previous = node;
                        if (traversal != Traversal.Block)
                            checkNext.Add(nextPoint);
                    }
                }
            }

            checkNow.Clear();
            checkNow.AddRange(checkNext);
            checkNext.Clear();
        }

        return new PathMap(map);
    }
}
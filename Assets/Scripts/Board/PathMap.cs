using System.Collections.Generic;

public interface IPathMap
{
    PathNode this[Point point] { get; }
    bool TryGetNode(out PathNode node, Point point);
    List<Point> GetPathToPoint(Point point);
    List<Point> AllPoints();
    List<Point> OpenPoints(int range);
    Point NearestOpen(Point point, int range);
}

public class PathMap : IPathMap
{
    private readonly Dictionary<Point, PathNode> map;

    public PathMap(Dictionary<Point, PathNode> map)
    {
        this.map = map;
    }

    public PathNode this[Point point] => map[point];

    public bool TryGetNode(out PathNode node, Point point)
    {
        if (map.ContainsKey(point))
        {
            node = map[point];
            return true;
        }

        node = null;
        return false;
    }

    public List<Point> GetPathToPoint(Point point)
    {
        var result = new List<Point>();
        var node = map.ContainsKey(point) ? map[point] : null;
        while (node != null)
        {
            result.Add(node.point);
            node = node.previous;
        }

        result.Reverse();
        return result;
    }

    public List<Point> AllPoints()
    {
        return new List<Point>(map.Keys);
    }

    public List<Point> OpenPoints(int range)
    {
        var result = new List<Point>();
        foreach (var entry in map)
        {
            var node = entry.Value;
            if (node.traversal == Traversal.Open && node.moveCost <= range)
                result.Add(entry.Key);
        }

        return result;
    }

    public Point NearestOpen(Point point, int range)
    {
        var node = map[point];
        while (node.moveCost > range || node.traversal != Traversal.Open) node = node.previous;
        return node.point;
    }
}
public class PathNode
{
    public bool diagonalActive;
    public int moveCost;
    public Point point;
    public PathNode previous;

    public PathNode(Point point, int moveCost, bool diagonalActive, PathNode previous)
    {
        this.point = point;
        this.moveCost = moveCost;
        this.diagonalActive = diagonalActive;
        this.previous = previous;
    }
}
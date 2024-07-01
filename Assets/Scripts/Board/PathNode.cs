public enum Traversal
{
    Open, // Can move through or stop here
    Pass, // Can move through but not stop here
    Block, // A point on the board, but can not move through or stop here
    OffBoard // A point not even on the board
}

public class PathNode
{
    public bool diagonalActive;
    public int moveCost;
    public Point point;
    public PathNode previous;
    public Traversal traversal;

    public PathNode(Point point, int moveCost, bool diagonalActive, PathNode previous, Traversal traversal)
    {
        this.point = point;
        this.moveCost = moveCost;
        this.diagonalActive = diagonalActive;
        this.previous = previous;
        this.traversal = traversal;
    }
}
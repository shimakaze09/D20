#region

using System;
using UnityEngine;

#endregion

[Serializable]
public struct Point : IEquatable<Point>
{
    public int x;
    public int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static Point operator +(Point lhs, Point rhs)
    {
        return new Point(lhs.x + rhs.x, lhs.y + rhs.y);
    }

    public static Point operator -(Point lhs, Point rhs)
    {
        return new Point(lhs.x - rhs.x, lhs.y - rhs.y);
    }

    public static bool operator ==(Point lhs, Point rhs)
    {
        return lhs.x == rhs.x && lhs.y == rhs.y;
    }

    public static bool operator !=(Point lhs, Point rhs)
    {
        return !(lhs == rhs);
    }

    public static explicit operator Point(Vector3 v)
    {
        return new Point(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));
    }

    public static implicit operator Vector3(Point p)
    {
        return new Vector3(p.x, p.y, 0);
    }

    public override bool Equals(object obj)
    {
        if (obj is Point)
        {
            var p = (Point)obj;
            return this == p;
        }

        return false;
    }

    public bool Equals(Point p)
    {
        return this == p;
    }

    public override int GetHashCode()
    {
        return (x, y).GetHashCode();
    }

    public override string ToString()
    {
        return string.Format("Point(x:{0}, y:{1})", x, y);
    }
}
using System;

[Serializable]
public partial struct Entity
{
    public static readonly Entity None = new(0);

    public int id;

    public Entity(int id)
    {
        this.id = id;
    }

    public static bool operator ==(Entity lhs, Entity rhs)
    {
        return lhs.id == rhs.id;
    }

    public static bool operator !=(Entity lhs, Entity rhs)
    {
        return !(lhs == rhs);
    }

    public override bool Equals(object obj)
    {
        return Equals((Entity)obj);
    }

    public override int GetHashCode()
    {
        return id.GetHashCode();
    }

    public bool Equals(Entity p)
    {
        return this == p;
    }
}
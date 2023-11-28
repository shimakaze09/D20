[System.Serializable]
public partial struct Entity
{
    public static readonly Entity None = new(0);

    public int id;

    public Entity(int id)
    {
        this.id = id;
    }

    public static bool operator ==(Entity lhs, Entity rhs) => lhs.id == rhs.id;

    public static bool operator !=(Entity lhs, Entity rhs) => !(lhs == rhs);

    public override bool Equals(object obj) => this.Equals((Entity)obj);

    public override int GetHashCode() => id.GetHashCode();

    public bool Equals(Entity p) => this == p;
}
public partial class Data
{
    public CoreDictionary<Entity, Point> position = new();
}

public interface IPositionSystem : IDependency<IPositionSystem>,
    IEntityTableSystem<Point>
{
}

public class PositionSystem : EntityTableSystem<Point>, IPositionSystem
{
    public override CoreDictionary<Entity, Point> Table =>
        IDataSystem.Resolve().Data.position;
}

public partial struct Entity
{
    public Point Position
    {
        get => IPositionSystem.Resolve().Get(this);
        set => IPositionSystem.Resolve().Set(this, value);
    }
}
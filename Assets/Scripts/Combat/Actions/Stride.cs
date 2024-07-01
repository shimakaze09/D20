#region

using Cysharp.Threading.Tasks;
using UnityEngine;

#endregion

public interface IStridePositionSelector
{
    Point SelectPosition(Entity entity, IPathMap map);
}

public class Stride : MonoBehaviour, ICombatAction
{
    [SerializeField] private EntityFilter passFilter;
    [SerializeField] private EntityFilter blockFilter;

    public bool CanPerform(Entity entity)
    {
        return true;
    }

    public async UniTask Perform(Entity entity)
    {
        var pass = ISpaceSystem.Resolve().OccupiedSpaces(passFilter.Fetch(entity));
        var block = ISpaceSystem.Resolve().OccupiedSpaces(blockFilter.Fetch(entity));
        var traverser = new LandTraverser(pass, block);
        var range = entity.Party == Party.Hero ? entity.Speed : int.MaxValue;

        var map = IPathfindingSystem.Resolve().Map(
            entity.Position,
            range,
            entity.Size,
            traverser);

        Point position;
        if (entity.Party == Party.Hero)
            position = await UserSelection(entity, map);
        else
            position = ComputerSelection(entity, map);

        var info = new StrideInfo
        {
            entity = entity,
            path = map.GetPathToPoint(position)
        };

        await IStrideSystem.Resolve().Apply(info);
    }

    private async UniTask<Point> UserSelection(Entity entity, IPathMap map)
    {
        var openPoints = map.OpenPoints(entity.Speed);
        IBoardHighlightSystem.Resolve().Highlight(
            openPoints,
            new Color(0, 1, 1, 0.5f));

        Point position;
        while (true)
        {
            position = await IPositionSelectionSystem.Resolve().Select(entity.Position);
            if (openPoints.Contains(position))
                break;
        }

        IBoardHighlightSystem.Resolve().ClearHighlights();
        return position;
    }

    private Point ComputerSelection(Entity entity, IPathMap map)
    {
        var selector = GetComponent<IStridePositionSelector>();
        if (selector != null)
            return selector.SelectPosition(entity, map);
        return entity.Position;
    }
}
#region

using System.Collections.Generic;
using Cysharp.Threading.Tasks;

#endregion

public struct StrideInfo
{
    public Entity entity;
    public List<Point> path;
}

public interface IStrideSystem : IDependency<IStrideSystem>
{
    UniTask Apply(StrideInfo info);
}

public class StrideSystem : IStrideSystem
{
    public async UniTask Apply(StrideInfo info)
    {
        // TODO: Check for act of opportunity before leaving current square
        if (info.entity.Position != info.path[info.path.Count - 1])
            await Present(info);
        Perform(info);
        // TODO: Check for act of opportunity after arriving at new square
    }

    private async UniTask Present(StrideInfo info)
    {
        IStridePresenter presenter;
        if (IStridePresenter.TryResolve(out presenter))
        {
            var presentInfo = new StridePresentationInfo
            {
                entity = info.entity,
                path = info.path
            };
            await presenter.Present(presentInfo);
        }
    }

    private void Perform(StrideInfo info)
    {
        var entity = info.entity;
        entity.Position = info.path[info.path.Count - 1];
        ITurnSystem.Resolve().TakeAction(1, false);
    }
}
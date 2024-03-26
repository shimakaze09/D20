using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public struct StridePresentationInfo
{
    public Entity entity;
    public List<Point> path;
}

public interface IStridePresenter : IDependency<IStridePresenter>
{
    UniTask Present(StridePresentationInfo info);
}

public class StridePresenter : MonoBehaviour, IStridePresenter
{
    [SerializeField] private float moveSpeed = 0.25f;

    private void OnEnable()
    {
        IStridePresenter.Register(this);
    }

    private void OnDisable()
    {
        IStridePresenter.Reset();
    }

    public async UniTask Present(StridePresentationInfo info)
    {
        var view = IEntityViewProvider.Resolve().GetView(info.entity, ViewZone.Combatant);
        var combatant = view.GetComponent<CombatantView>();
        ICombatantViewSystem.Resolve().SetAnimation(combatant, CombatantAnimation.Walk);

        var previous = info.path[0];
        for (var i = 1; i < info.path.Count; ++i)
        {
            var next = info.path[i];
            ICombatSelectionIndicator.Resolve().SetPosition(next);
            await view.transform.MoveTo(next, moveSpeed).Play();
            ICombatantViewSystem.Resolve().SetLayerOrder(combatant, next.y);
            previous = next;
        }

        ICombatantViewSystem.Resolve().SetAnimation(combatant, CombatantAnimation.Idle);
    }
}
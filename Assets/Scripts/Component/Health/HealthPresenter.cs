#region

using Cysharp.Threading.Tasks;
using UnityEngine;

#endregion

public struct HealthPresentationInfo
{
    public Entity target;
    public int amount;
}

public interface IHealthPresenter : IDependency<IHealthPresenter>
{
    UniTask Present(HealthPresentationInfo info);
}

public class HealthPresenter : MonoBehaviour, IHealthPresenter
{
    private void OnEnable()
    {
        IHealthPresenter.Register(this);
    }

    private void OnDisable()
    {
        IHealthPresenter.Reset();
    }

    public async UniTask Present(HealthPresentationInfo info)
    {
        var view = IEntityViewProvider.Resolve().GetView(info.target, ViewZone.Combatant);
        var combatantUI = view.GetComponentInChildren<CombatantUI>();
        combatantUI.healthSlider.value = info.target.Health;
        await UniTask.CompletedTask;
    }
}
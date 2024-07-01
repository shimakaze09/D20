#region

using Cysharp.Threading.Tasks;
using UnityEngine;

#endregion

public struct AttackPresentationInfo
{
    public Entity attacker;
    public Entity target;
    public Check result;
}

public interface IAttackPresenter : IDependency<IAttackPresenter>
{
    UniTask Present(AttackPresentationInfo info);
}

public class AttackPresenter : MonoBehaviour, IAttackPresenter
{
    private void OnEnable()
    {
        IAttackPresenter.Register(this);
    }

    private void OnDisable()
    {
        IAttackPresenter.Reset();
    }

    public async UniTask Present(AttackPresentationInfo info)
    {
        var view = IEntityViewProvider.Resolve().GetView(info.attacker, ViewZone.Combatant);
        var combatant = view.GetComponent<CombatantView>();
        await ICombatantViewSystem.Resolve().PlayAnimation(combatant, CombatantAnimation.Attack);
    }
}
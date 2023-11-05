using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Linq;

public class SoloAdventureAttack : MonoBehaviour, ICombatAction
{
    [SerializeField] private int attackRollBonus;
    [SerializeField] private int comboCost;
    [SerializeField] private DiceRoll damage;

    public async UniTask Perform(Entity entity)
    {
        var attacker = ITurnSystem.Resolve().Current;
        var target = ICombatantSystem.Resolve().Table.First(c => c.Party != attacker.Party);

        // Perform the Attack Roll
        var attackInfo = new AttackRollInfo
        {
            attacker = attacker,
            target = target,
            attackRollBonus = attackRollBonus,
            comboCost = comboCost
        };
        var attackRoll = IAttackRollSystem.Resolve().Perform(attackInfo);

        // Present the Attack
        IAttackPresenter presenter;
        if (IAttackPresenter.TryResolve(out presenter))
        {
            var presentInfo = new AttackPresentationInfo
            {
                attacker = attacker,
                target = target,
                result = attackRoll
            };
            await presenter.Present(presentInfo);
        }

        // TODO: Apply Damage if applicable
        switch (attackRoll)
        {
            case Check.CriticalSuccess:
                Debug.Log($"Critical Hit for {damage.Roll() * 2} Damage!");
                break;
            case Check.Success:
                Debug.Log($"Hit for {damage.Roll()} Damage!");
                break;
            default:
                Debug.Log("Miss");
                break;
        }
    }
}
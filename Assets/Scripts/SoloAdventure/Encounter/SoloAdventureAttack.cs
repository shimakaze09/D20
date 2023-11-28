using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Linq;

public class SoloAdventureAttack : MonoBehaviour, ICombatAction
{
    [SerializeField] private int attackRollBonus;
    [SerializeField] private int comboCost;
    [SerializeField] private DiceRoll damage;
    [SerializeField] private string damageType;
    [SerializeField] private string material;

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

        // Determine Damage
        DamageInfo damageInfo = new()

        {
            target = target,
            damage = 0,
            criticalDamage = 0,
            type = damageType,
            material = material
        };
        switch (attackRoll)
        {
            case Check.CriticalSuccess:
                var critRoll = damage.Roll();
                damageInfo.damage = critRoll;
                damageInfo.criticalDamage = critRoll;
                Debug.Log(string.Format("Critical Hit for {0} Damage!", critRoll * 2));
                break;
            case Check.Success:
                var roll = damage.Roll();
                damageInfo.damage = roll;
                Debug.Log(string.Format("Hit for {0} Damage!", roll));
                break;
            default:
                Debug.Log("Miss");
                break;
        }

        // TODO: Apply Damage if applicable
        var damageAmount = IDamageSystem.Resolve().Apply(damageInfo);
        Debug.Log("Final Damage: " + damageAmount);
    }
}
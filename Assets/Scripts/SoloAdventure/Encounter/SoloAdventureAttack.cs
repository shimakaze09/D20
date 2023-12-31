using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SoloAdventureAttack : MonoBehaviour, ICombatAction
{
    [SerializeField] private int attackRollBonus;
    [SerializeField] private int comboCost;
    [SerializeField] private DiceRoll damage;
    [SerializeField] private string damageType;
    [SerializeField] private string material;

    public async UniTask Perform(Entity entity)
    {
        var attacker = entity;
        var target = await SelectTarget(entity);

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
        var damageInfo = new DamageInfo
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

        // Apply Damage
        var damageAmount = IDamageSystem.Resolve().Apply(damageInfo);
        var healthInfo = new HealthInfo
        {
            target = target,
            amount = -damageAmount
        };
        await IHealthSystem.Resolve().Apply(healthInfo);
    }

    private async UniTask<Entity> SelectTarget(Entity entity)
    {
        if (entity.Party == Party.Monster)
            return ICombatantSystem.Resolve().Table.First(c => c.Party != entity.Party);

        var layerMask = LayerMask.GetMask("Hero");
        Entity? target = null;
        while (!target.HasValue)
        {
            var position = await IPositionSelectionSystem.Resolve().Select(entity.Position);
            target = IPhysicsSystem.Resolve().OverlapPoint(position, layerMask);
        }

        return target.Value;
    }
}
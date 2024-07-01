#region

using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

#endregion

public class SoloAdventureAttack : MonoBehaviour, ICombatAction
{
    [SerializeField] private int attackRollBonus;
    [SerializeField] private int comboCost;
    [SerializeField] private DiceRoll damage;
    [SerializeField] private string damageType;
    [SerializeField] private string material;
    [SerializeField] private EntityFilter targetFilter;

    public bool CanPerform(Entity entity)
    {
        return targetFilter.Apply(entity, ITurnSystem.Resolve().InReach).Count > 0;
    }

    public async UniTask Perform(Entity entity)
    {
        var targets = targetFilter.Apply(entity, ITurnSystem.Resolve().InReach);
        if (targets.Count == 0)
            return;

        var attacker = entity;
        var target = await SelectTarget(entity, targets);

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
                Debug.Log($"Critical Hit for {critRoll * 2} Damage!");
                break;
            case Check.Success:
                var roll = damage.Roll();
                damageInfo.damage = roll;
                Debug.Log($"Hit for {roll} Damage!");
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

    private async UniTask<Entity> SelectTarget(Entity entity, List<Entity> targets)
    {
        if (entity.Party == Party.Monster)
            return targets[0];
        return await IEntitySelectionSystem.Resolve().Select(targets);
    }
}
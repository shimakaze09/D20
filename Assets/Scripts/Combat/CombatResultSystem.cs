#region

using System.Linq;

#endregion

public enum CombatResult
{
    Victory,
    Defeat
}

public interface ICombatResultSystem : IDependency<ICombatResultSystem>
{
    CombatResult? CheckResult();
}

public class CombatResultSystem : ICombatResultSystem
{
    public CombatResult? CheckResult()
    {
        var combatants = ICombatantSystem.Resolve().Table;

        var heroAlive = combatants.Any(e => e.Party == Party.Hero && e.HitPoints > 0);
        if (!heroAlive)
            return CombatResult.Defeat;

        var enemyAlive = combatants.Any(e => e.Party == Party.Monster && e.HitPoints > 0);
        if (!enemyAlive)
            return CombatResult.Victory;

        return null;
    }
}
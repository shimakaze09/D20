using UnityEngine;

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
        if (Input.GetKeyUp(KeyCode.V))
            return CombatResult.Victory;
        if (Input.GetKeyUp(KeyCode.D))
            return CombatResult.Defeat;
        return null;
    }
}
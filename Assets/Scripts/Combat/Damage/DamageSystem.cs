#region

using System.Collections.Generic;
using UnityEngine;

#endregion

public struct DamageInfo
{
    public Entity target;
    public int damage;
    public int criticalDamage;
    public string type;
    public string material;
}

public interface IDamageTypeSystem
{
    bool GetImmunity(DamageInfo info);
    int GetWeakness(DamageInfo info);
    int GetResistance(DamageInfo info);
}

public interface IDamageSystem : IDependency<IDamageSystem>
{
    int Apply(DamageInfo info);
    void Add(IDamageTypeSystem damageTypeSystem);
}

public class DamageSystem : IDamageSystem
{
    private readonly List<IDamageTypeSystem> damageTypeSystems = new();

    public int Apply(DamageInfo info)
    {
        // Step 1: Check for Immunity
        foreach (var system in damageTypeSystems)
            if (system.GetImmunity(info))
                return 0;

        var result = info.damage + info.criticalDamage;

        // Step 2: Check for Weaknesses
        foreach (var system in damageTypeSystems)
            result += system.GetWeakness(info);

        // Step 3: Check for Resistances
        foreach (var system in damageTypeSystems)
            result -= system.GetResistance(info);

        return Mathf.Max(result, 0);
    }

    public void Add(IDamageTypeSystem damageTypeSystem)
    {
        damageTypeSystems.Add(damageTypeSystem);
    }
}
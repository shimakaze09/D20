#region

using UnityEngine;

#endregion

public class DamageWeaknessProvider : MonoBehaviour, IAttributeProvider
{
    [SerializeField] private string damageType;
    [SerializeField] private int amount;

    public void Setup(Entity entity)
    {
        IDamageWeaknessSystem.Resolve().SetWeakness(entity, damageType, amount);
    }
}
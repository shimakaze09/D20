using UnityEngine;

public class DamageWeaknessProvider : MonoBehaviour, IAttributeProvider
{
    [SerializeField] private int amount;
    [SerializeField] private string damageType;

    public void Setup(Entity entity)
    {
        IDamageWeaknessSystem.Resolve().SetWeakness(entity, damageType, amount);
    }
}
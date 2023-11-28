using UnityEngine;

public class DamageResistanceProvider : MonoBehaviour, IAttributeProvider
{
    [SerializeField] private string damageType;
    [SerializeField] private int amount;
    [SerializeField] private string exception;

    public void Setup(Entity entity)
    {
        IDamageResistanceSystem.Resolve().SetResistance(entity, damageType, amount);
        if (!string.IsNullOrEmpty(exception))
            IDamageResistanceExceptionSystem.Resolve().SetException(entity, damageType, exception);
    }
}
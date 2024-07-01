#region

using UnityEngine;

#endregion

public class DamageImmunityProvider : MonoBehaviour, IAttributeProvider
{
    [SerializeField] private string damageType;

    public void Setup(Entity entity)
    {
        IDamageImmunitySystem.Resolve().AddImmunity(entity, damageType);
    }
}
#region

using UnityEngine;

#endregion

public class CombatantProvider : MonoBehaviour, IAttributeProvider
{
    public void Setup(Entity entity)
    {
        entity.IsCombatant = true;
    }
}
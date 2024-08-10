#region

using UnityEngine;

#endregion

public class WeaponGroupProvider : MonoBehaviour, IAttributeProvider
{
    public WeaponGroup value;

    public void Setup(Entity entity)
    {
        entity.WeaponGroup = value;
    }
}
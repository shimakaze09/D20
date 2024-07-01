#region

using UnityEngine;

#endregion

public class SpeedProvider : MonoBehaviour, IAttributeProvider
{
    public int value;

    public void Setup(Entity entity)
    {
        entity.Speed = value;
    }
}
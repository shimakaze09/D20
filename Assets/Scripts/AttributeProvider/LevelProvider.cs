#region

using UnityEngine;

#endregion

public class LevelProvider : MonoBehaviour, IAttributeProvider
{
    public int value;

    public void Setup(Entity entity)
    {
        entity.Level = value;
    }
}
#region

using UnityEngine;

#endregion

public class SizeProvider : MonoBehaviour, IAttributeProvider
{
    public Size value;

    public void Setup(Entity entity)
    {
        entity.Size = value;
    }
}
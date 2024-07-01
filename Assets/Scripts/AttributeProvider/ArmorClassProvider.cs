#region

using UnityEngine;

#endregion

public class ArmorClassProvider : MonoBehaviour, IAttributeProvider
{
    [SerializeField] private int value;

    public void Setup(Entity entity)
    {
        entity.ArmorClass = value;
    }
}
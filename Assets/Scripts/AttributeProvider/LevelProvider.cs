#region

using UnityEngine;

#endregion

public class LevelProvider : MonoBehaviour, IAttributeProvider
{
    [SerializeField] private int value;

    public void Setup(Entity entity)
    {
        entity.Level = value;
    }
}
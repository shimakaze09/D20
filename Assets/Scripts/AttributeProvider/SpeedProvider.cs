using UnityEngine;

public class SpeedProvider : MonoBehaviour, IAttributeProvider
{
    [SerializeField] private int value;

    public void Setup(Entity entity)
    {
        entity.Speed = value;
    }
}
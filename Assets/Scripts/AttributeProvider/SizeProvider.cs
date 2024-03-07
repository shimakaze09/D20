using UnityEngine;

public class SizeProvider : MonoBehaviour, IAttributeProvider
{
    [SerializeField] private Size value;

    public void Setup(Entity entity)
    {
        entity.Size = value;
    }
}
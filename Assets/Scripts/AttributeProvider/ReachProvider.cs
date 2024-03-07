using UnityEngine;

public class ReachProvider : MonoBehaviour, IAttributeProvider
{
    [SerializeField] private Reach value;

    public void Setup(Entity entity)
    {
        entity.Reach = value;
    }
}
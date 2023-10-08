using UnityEngine;

public class AbilityScoreProvider : MonoBehaviour, IAttributeProvider
{
    [SerializeField] AbilityScore.Attribute attribute;
    [SerializeField] int value;

    public void Setup(Entity entity)
    {
        entity[attribute] = value;
    }
}
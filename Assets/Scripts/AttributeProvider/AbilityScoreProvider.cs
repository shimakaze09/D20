#region

using UnityEngine;

#endregion

public class AbilityScoreProvider : MonoBehaviour, IAttributeProvider
{
    [SerializeField] private AbilityScore.Attribute attribute;
    [SerializeField] private int value;

    public void Setup(Entity entity)
    {
        entity[attribute] = value;
    }
}
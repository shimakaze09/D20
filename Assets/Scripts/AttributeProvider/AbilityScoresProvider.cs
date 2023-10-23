using UnityEngine;

public class AbilityScoresProvider : MonoBehaviour, IAttributeProvider
{
    [SerializeField] private int strength;
    [SerializeField] private int dexterity;
    [SerializeField] private int constitution;
    [SerializeField] private int intelligence;
    [SerializeField] private int wisdom;
    [SerializeField] private int charisma;

    public void Setup(Entity entity)
    {
        entity.Strength = strength;
        entity.Dexterity = dexterity;
        entity.Constitution = constitution;
        entity.Intelligence = intelligence;
        entity.Wisdom = wisdom;
        entity.Charisma = charisma;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AbilityScore
{
    public enum Attribute
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }

    public int value;

    public int Modifier => value / 2 - 5;

    public AbilityScore(int value)
    {
        this.value = value;
    }

    public static implicit operator int(AbilityScore score)
    {
        return score.value;
    }

    public static implicit operator AbilityScore(int score)
    {
        return new AbilityScore(score);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IAbilityScoreSystem : IDependency<IAbilityScoreSystem>
{
    AbilityScore Get(Entity entity, AbilityScore.Attribute attribute);
    void Set(Entity entity, AbilityScore.Attribute attribute, AbilityScore value);
    void Set(Entity entity, IEnumerable<int> scores);
}

public class AbilityScoreSystem : IAbilityScoreSystem
{
    public void Set(Entity entity, IEnumerable<int> scores)
    {
        Debug.Assert(scores.Count() == 6, "Incorrect ability score count");
        IStrengthSystem.Resolve().Set(entity, scores.ElementAt(0));
        IDexteritySystem.Resolve().Set(entity, scores.ElementAt(1));
        IConstitutionSystem.Resolve().Set(entity, scores.ElementAt(2));
        IIntelligenceSystem.Resolve().Set(entity, scores.ElementAt(3));
        IWisdomSystem.Resolve().Set(entity, scores.ElementAt(4));
        ICharismaSystem.Resolve().Set(entity, scores.ElementAt(5));
    }

    public AbilityScore Get(Entity entity, AbilityScore.Attribute attribute)
    {
        return attribute switch
        {
            AbilityScore.Attribute.Strength => IStrengthSystem.Resolve().Get(entity),
            AbilityScore.Attribute.Dexterity => IDexteritySystem.Resolve().Get(entity),
            AbilityScore.Attribute.Constitution => IConstitutionSystem.Resolve().Get(entity),
            AbilityScore.Attribute.Intelligence => IIntelligenceSystem.Resolve().Get(entity),
            AbilityScore.Attribute.Wisdom => IWisdomSystem.Resolve().Get(entity),
            AbilityScore.Attribute.Charisma => ICharismaSystem.Resolve().Get(entity),
            _ => 0
        };
    }

    public void Set(Entity entity, AbilityScore.Attribute attribute, AbilityScore value)
    {
        switch (attribute)
        {
            case AbilityScore.Attribute.Strength:
                IStrengthSystem.Resolve().Set(entity, value);
                break;
            case AbilityScore.Attribute.Dexterity:
                IDexteritySystem.Resolve().Set(entity, value);
                break;
            case AbilityScore.Attribute.Constitution:
                IConstitutionSystem.Resolve().Set(entity, value);
                break;
            case AbilityScore.Attribute.Intelligence:
                IIntelligenceSystem.Resolve().Set(entity, value);
                break;
            case AbilityScore.Attribute.Wisdom:
                IWisdomSystem.Resolve().Set(entity, value);
                break;
            case AbilityScore.Attribute.Charisma:
                ICharismaSystem.Resolve().Set(entity, value);
                break;
        }
    }
}

public partial struct Entity
{
    public AbilityScore this[AbilityScore.Attribute attribute]
    {
        get => IAbilityScoreSystem.Resolve().Get(this, attribute);
        set => IAbilityScoreSystem.Resolve().Set(this, attribute, value);
    }
}
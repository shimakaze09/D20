using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillsProficiencyProvider : MonoBehaviour, IAttributeProvider
{
    [SerializeField] private List<ValuePair> valuePairs;

    public void Setup(Entity entity)
    {
        var system = IProficiencySystem.Resolve();
        foreach (var pair in valuePairs)
            system.Set(entity, pair.skill, pair.proficiency);
    }

    [Serializable]
    public struct ValuePair
    {
        public Skill skill;
        public Proficiency proficiency;
    }
}
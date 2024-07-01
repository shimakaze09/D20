#region

using System;
using System.Collections.Generic;
using UnityEngine;

#endregion

public class SkillsProficiencyProvider : MonoBehaviour, IAttributeProvider
{
    public List<ValuePair> valuePairs;

    public void Setup(Entity entity)
    {
        var system = ISkillProficiencySystem.Resolve();
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
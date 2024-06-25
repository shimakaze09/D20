﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class SavingThrowsProficiencyProvider : MonoBehaviour, IAttributeProvider
{
    public List<ValuePair> valuePairs;

    public void Setup(Entity entity)
    {
        var system = ISavingThrowProficiencySystem.Resolve();
        foreach (var pair in valuePairs)
            system.Set(entity, pair.savingThrow, pair.proficiency);
    }

    [Serializable]
    public struct ValuePair
    {
        public SavingThrow savingThrow;
        public Proficiency proficiency;
    }
}
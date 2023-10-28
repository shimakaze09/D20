using System.Collections.Generic;
using UnityEngine;

public class EncounterActionsProvider : MonoBehaviour, IAttributeProvider
{
    [SerializeField] private List<string> value;

    public void Setup(Entity entity)
    {
        entity.EncounterActions = value;
    }
}
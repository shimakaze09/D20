#region

using UnityEngine;

#endregion

public class EncounterEntryOption : MonoBehaviour, IEntryOption
{
    [SerializeField] private string text;
    [SerializeField] private string encounterName;
    public string Text => text;

    public void Select()
    {
        IEncounterSystem.Resolve().SetName(encounterName);
    }
}
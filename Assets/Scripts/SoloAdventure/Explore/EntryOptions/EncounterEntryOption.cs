using UnityEngine;

public class EncounterEntryOption : MonoBehaviour, IEntryOption
{
    public string Text => text;
    [SerializeField] private string text;
    [SerializeField] private string encounterName;

    public void Select()
    {
        IEncounterSystem.Resolve().SetName(encounterName);
    }
}
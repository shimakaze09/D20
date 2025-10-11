using UnityEngine;

public class EncounterEntryOption : MonoBehaviour, IEntryOption
{
    [SerializeField] private string encounterName;
    [SerializeField] private string text;
    public string Text => text;

    public void Select()
    {
        IEncounterSystem.Resolve().SetName(encounterName);
    }
}
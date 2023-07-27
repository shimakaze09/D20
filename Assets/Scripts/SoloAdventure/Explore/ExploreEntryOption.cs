using UnityEngine;

public class ExploreEntryOption : MonoBehaviour, IEntryOption
{
    public string Text => text;

    [SerializeField] private string text;
    [SerializeField] private string entryName;

    public void Select()
    {
        IEntrySystem.Resolve().SetName(entryName);
    }
}
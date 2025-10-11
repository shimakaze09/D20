using UnityEngine;

public class ExploreEntryOption : MonoBehaviour, IEntryOption
{
    [SerializeField] private string entryName;
    [SerializeField] private string text;
    public string Text => text;

    public void Select()
    {
        IEntrySystem.Resolve().SetName(entryName);
    }
}
#region

using UnityEngine;

#endregion

public class ExploreEntryOption : MonoBehaviour, IEntryOption
{
    [SerializeField] private string text;
    [SerializeField] private string entryName;
    public string Text => text;

    public void Select()
    {
        IEntrySystem.Resolve().SetName(entryName);
    }
}
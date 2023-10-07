using UnityEngine;

public class ExploreEntryOption : MonoBehaviour, IEntryOption
{
    public string Text { get { return text; } }
    [SerializeField] string text;
    [SerializeField] string entryName;    

    public void Select()
    {
        IEntrySystem.Resolve().SetName(entryName);
    }
}
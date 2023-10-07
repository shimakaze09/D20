using UnityEngine;

public class ItemExploreEntryOption : MonoBehaviour, IEntryOption
{
    [SerializeField] string text;
    [SerializeField] AdventureItem item;
    [SerializeField] string hasItemEntry;
    [SerializeField] string noItemEntry;

    public string Text
    {
        get { return text; }
    }

    public void Select()
    {
        var entry = IAdventureItemSystem.Resolve().Has(item) ? hasItemEntry : noItemEntry;
        IEntrySystem.Resolve().SetName(entry);
    }
}

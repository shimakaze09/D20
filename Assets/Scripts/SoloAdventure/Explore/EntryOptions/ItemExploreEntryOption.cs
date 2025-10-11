using UnityEngine;

public class ItemExploreEntryOption : MonoBehaviour, IEntryOption
{
    [SerializeField] private string hasItemEntry;
    [SerializeField] private AdventureItem item;
    [SerializeField] private string noItemEntry;
    [SerializeField] private string text;

    public string Text => text;

    public void Select()
    {
        var entry = IAdventureItemSystem.Resolve().Has(item) ? hasItemEntry : noItemEntry;
        IEntrySystem.Resolve().SetName(entry);
    }
}
using UnityEngine;

public interface IEntry
{
    string Text { get; }
    IEntryOption[] Options { get; }
}

public class Entry : MonoBehaviour, IEntry
{
    [SerializeField] private string text;
    public string Text => text;

    public IEntryOption[] Options => GetComponents<IEntryOption>();
}
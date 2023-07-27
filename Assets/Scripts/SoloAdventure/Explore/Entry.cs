using UnityEngine;

public interface IEntry
{
    string Text { get; }
    IEntryOption[] Options { get; }
}

public class Entry : MonoBehaviour, IEntry
{
    public string Text => text;

    [SerializeField] private string text;

    public IEntryOption[] Options => GetComponents<IEntryOption>();
}
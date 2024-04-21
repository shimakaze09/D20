using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IEntry
{
    string Text { get; }
    IEntryOption[] Options { get; }
    UniTask SelectLink(string link);
}

public class Entry : MonoBehaviour, IEntry
{
    [SerializeField] private string text;
    public string Text => text;

    public IEntryOption[] Options => GetComponents<IEntryOption>();

    public async UniTask SelectLink(string link)
    {
        await GetComponent<IEntryLink>().Select(link);
    }
}
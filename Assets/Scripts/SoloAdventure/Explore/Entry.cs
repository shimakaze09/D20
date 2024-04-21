using UnityEngine;
using Cysharp.Threading.Tasks;

public interface IEntry
{
    string Text { get; }
    IEntryOption[] Options { get; }
    UniTask SelectLink(string link);
}

public class Entry : MonoBehaviour, IEntry
{
    public string Text => text;
    [SerializeField] private string text;

    public IEntryOption[] Options => GetComponents<IEntryOption>();

    public async UniTask SelectLink(string link)
    {
        await GetComponent<IEntryLink>().Select(link);
    }
}
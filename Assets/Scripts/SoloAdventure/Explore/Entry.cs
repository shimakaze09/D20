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
    public string Text { get { return text; } }
    [SerializeField] string text;

    public IEntryOption[] Options
    {
        get
        {
            return GetComponents<IEntryOption>();
        }
    }

    public async UniTask SelectLink(string link)
    {
        await GetComponent<IEntryLink>().Select(link);
    }
}
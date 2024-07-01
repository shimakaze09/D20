#region

using Cysharp.Threading.Tasks;

#endregion

public interface IEntryLink
{
    UniTask Select(string link);
}
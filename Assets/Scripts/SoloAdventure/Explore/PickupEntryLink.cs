using Cysharp.Threading.Tasks;
using UnityEngine;

public class PickupEntryLink : MonoBehaviour, IEntryLink
{
    [SerializeField] private string dropMessage;
    [SerializeField] private AdventureItem item;
    [SerializeField] private string takeMessage;

    public async UniTask Select(string link)
    {
        if (link != "pickup")
            return;

        var system = IAdventureItemSystem.Resolve();
        if (!system.Has(item))
        {
            system.Take(item);
            await IAlert.Resolve().Show(takeMessage);
        }
        else
        {
            system.Drop(item);
            await IAlert.Resolve().Show(dropMessage);
        }
    }
}
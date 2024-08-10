#region

using Cysharp.Threading.Tasks;
using UnityEngine;

#endregion

public class PrimaryWeaponProvider : MonoBehaviour, IAttributeProvider
{
    public string recipeName;

    public async UniTask SetupFlow(Entity entity)
    {
        var weapon = await IWeaponAssetSystem.Resolve().Spawn(recipeName);
        entity.PrimaryHand = weapon;
    }
}
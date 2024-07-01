#region

using Cysharp.Threading.Tasks;
using UnityEngine;

#endregion

public interface ICombatActionAssetSystem : IDependency<ICombatActionAssetSystem>
{
    UniTask<ICombatAction> Load(string assetName);
}

public class CombatActionAssetSystem : ICombatActionAssetSystem
{
    public async UniTask<ICombatAction> Load(string assetName)
    {
        var assetManager = IAssetManager<GameObject>.Resolve();
        var key = $"Assets/Objects/CombatAction/{assetName}.prefab";
        var prefab = await assetManager.LoadAssetAsync(key);
        return prefab.GetComponent<ICombatAction>();
    }
}
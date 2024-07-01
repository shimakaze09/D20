#region

using Cysharp.Threading.Tasks;
using UnityEngine;

#endregion

public interface IAncestryAssetSystem : IDependency<IAncestryAssetSystem>
{
    UniTask<IAncestry> Load(string name);
}

public class AncestryAssetSystem : IAncestryAssetSystem
{
    public async UniTask<IAncestry> Load(string name)
    {
        var assetManager = IAssetManager<GameObject>.Resolve();
        var key = $"Assets/AutoGeneration/Ancestries/{name}.prefab";
        var prefab = await assetManager.LoadAssetAsync(key);
        return prefab.GetComponent<IAncestry>();
    }
}
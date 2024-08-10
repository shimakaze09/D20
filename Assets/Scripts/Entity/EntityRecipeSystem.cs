#region

using Cysharp.Threading.Tasks;
using UnityEngine;

#endregion

public interface IEntityRecipeSystem : IDependency<IEntityRecipeSystem>
{
    UniTask<Entity> Create(string assetName);
}

public class EntityRecipeSystem : IEntityRecipeSystem
{
    public async UniTask<Entity> Create(string assetName)
    {
        var entity = IEntitySystem.Resolve().Create();
        var assetManager = IAssetManager<GameObject>.Resolve();
        var key = string.Format("Assets/Objects/EntityRecipe/{0}.prefab", assetName);
        var prefab = await assetManager.LoadAssetAsync(key);
        var providers = prefab.GetComponents<IAttributeProvider>();
        for (var i = 0; i < providers.Length; ++i)
            await providers[i].SetupFlow(entity);
        return entity;
    }
}
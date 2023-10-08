using UnityEngine;
using Cysharp.Threading.Tasks;

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
        for (int i = 0; i < providers.Length; ++i)
            providers[i].Setup(entity);
        return entity;
    }
}
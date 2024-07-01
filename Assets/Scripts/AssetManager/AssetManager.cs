#region

using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

#endregion

public interface IAssetManager<T> : IDependency<IAssetManager<T>>
{
    UniTask<T> InstantiateAsync(string key);
    UniTask<T> LoadAssetAsync(string key);
}

public abstract class AssetManager<T> : MonoBehaviour, IAssetManager<T> where T : Object
{
    private readonly Dictionary<string, AsyncOperationHandle<T>> assetMap = new();

    private void OnEnable()
    {
        IAssetManager<T>.Register(this);
    }

    private void OnDisable()
    {
        IAssetManager<T>.Reset();
    }

    private void OnDestroy()
    {
        foreach (var handle in assetMap.Values)
            Addressables.Release(handle);
    }

    public async UniTask<T> InstantiateAsync(string key)
    {
        var asset = await LoadAssetAsync(key);
        return Instantiate(asset);
    }

    public async UniTask<T> LoadAssetAsync(string key)
    {
        AsyncOperationHandle<T> handle;
        if (assetMap.ContainsKey(key))
        {
            handle = assetMap[key];
        }
        else
        {
            handle = Addressables.LoadAssetAsync<T>(key);
            assetMap[key] = handle;
        }

        if (!handle.IsDone)
            await handle;

        if (handle.Status == AsyncOperationStatus.Succeeded)
            return handle.Result;

        return null;
    }
}
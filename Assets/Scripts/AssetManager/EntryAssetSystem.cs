﻿using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IEntryAssetSystem : IDependency<IEntryAssetSystem>
{
    UniTask<IEntry> Load();
    UniTask<IEntry> Load(string entryName);
}

public class EntryAssetSystem : IEntryAssetSystem
{
    public async UniTask<IEntry> Load()
    {
        var entryName = IEntrySystem.Resolve().GetName();
        return await Load(entryName);
    }

    public async UniTask<IEntry> Load(string entryName)
    {
        var assetManager = IAssetManager<GameObject>.Resolve();
        var key = $"Assets/Objects/Entries/{entryName}.prefab";
        var asset = await assetManager.LoadAssetAsync(key);
        return asset.GetComponent<IEntry>();
    }
}
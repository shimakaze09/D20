#region

using Cysharp.Threading.Tasks;
using UnityEngine;

#endregion

public interface IEncounterAssetSystem : IDependency<IEncounterAssetSystem>
{
    UniTask<IEncounter> Load();
    UniTask<IEncounter> Load(string entryName);
}

public class EncounterAssetSystem : IEncounterAssetSystem
{
    public async UniTask<IEncounter> Load()
    {
        var encounterName = IEncounterSystem.Resolve().GetName();
        return await Load(encounterName);
    }

    public async UniTask<IEncounter> Load(string encounterName)
    {
        var assetManager = IAssetManager<GameObject>.Resolve();
        var key = $"Assets/Objects/Encounters/{encounterName}.prefab";
        var prefab = await assetManager.LoadAssetAsync(key);
        return prefab.GetComponent<Encounter>();
    }
}
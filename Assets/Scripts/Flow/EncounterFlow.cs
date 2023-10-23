using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public interface IEncounterFlow : IDependency<IEncounterFlow>
{
    UniTask Play();
}

public class EncounterFlow : IEncounterFlow
{
    public async UniTask Play()
    {
        var encounter = await Enter();
        var combatResult = await Loop();
        await Exit(encounter, combatResult);
    }

    private async UniTask<IEncounter> Enter()
    {
        await SceneManager.LoadSceneAsync("Encounter");
        var asset = await IEncounterAssetSystem.Resolve().Load();
        return asset;
    }

    private async UniTask<CombatResult> Loop()
    {
        CombatResult? combatResult = null;
        while (!combatResult.HasValue)
        {
            await UniTask.NextFrame();
            combatResult = await IHeroActionFlow.Resolve().Play();
        }
        return combatResult.Value;
    }

    private async UniTask Exit(IEncounter asset, CombatResult result)
    {
        switch (result)
        {
            case CombatResult.Victory:
                IEntrySystem.Resolve().SetName(asset.VictoryEntry);
                break;
            case CombatResult.Defeat:
                IEntrySystem.Resolve().SetName(asset.DefeatEntry);
                break;
        }
        await UniTask.CompletedTask;
    }
}
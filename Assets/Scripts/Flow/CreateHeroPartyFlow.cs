#region

using Cysharp.Threading.Tasks;

#endregion

public interface ICreateHeroPartyFlow : IDependency<ICreateHeroPartyFlow>
{
    UniTask Play();
}

public class CreateHeroPartyFlow : ICreateHeroPartyFlow
{
    private const int heroPartySize = 4;

    private readonly string[] autoChosenAncestries =
    {
        "Dwarf",
        "Elf",
        "Gnome",
        "Halfling"
    };

    public async UniTask Play()
    {
        for (var i = 0; i < heroPartySize; ++i)
        {
            var entity = await IEntityRecipeSystem.Resolve().Create("Hero");
            entity.PartyOrder = i;
            await LoadAncestry(entity, autoChosenAncestries[i]);
            await LoadBackground(entity);
            ISkillSystem.Resolve().SetupAllSkills(entity);
            ISavingThrowSystem.Resolve().SetupAllSavingThrows(entity);
            IPerceptionSystem.Resolve().Setup(entity);
        }

        await UniTask.CompletedTask;
    }

    private async UniTask LoadAncestry(Entity entity, string ancestry)
    {
        entity.Ancestry = ancestry;
        var assetSystem = IAncestryAssetSystem.Resolve();
        var ancestryAsset = await assetSystem.Load(ancestry);
        foreach (var provider in ancestryAsset.AttributeProviders) await provider.SetupFlow(entity);
    }

    private async UniTask LoadBackground(Entity entity)
    {
        var backgroundAsset = await IBackgroundAssetSystem.Resolve().Load(entity.Background);
        foreach (var provider in backgroundAsset.AttributeProviders) await provider.SetupFlow(entity);
    }
}
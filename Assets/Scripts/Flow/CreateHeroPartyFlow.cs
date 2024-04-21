using Cysharp.Threading.Tasks;

public interface ICreateHeroPartyFlow : IDependency<ICreateHeroPartyFlow>
{
    UniTask Play();
}

public class CreateHeroPartyFlow : ICreateHeroPartyFlow
{
    private const int heroPartySize = 4;

    private string[] autoChosenAncestries = new string[]
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
        }

        await UniTask.CompletedTask;
    }

    private async UniTask LoadAncestry(Entity entity, string ancestry)
    {
        UnityEngine.Debug.Log(string.Format("Loading Ancestry: {0}", ancestry));
        entity.Ancestry = ancestry;
        var assetSystem = IAncestryAssetSystem.Resolve();
        var ancestryAsset = await assetSystem.Load(ancestry);
        foreach (var provider in ancestryAsset.AttributeProviders) provider.Setup(entity);
    }
}
#region

using Cysharp.Threading.Tasks;

#endregion

public interface IGameFlow : IDependency<IGameFlow>
{
    UniTask Play();
}

public class GameFlow : IGameFlow
{
    public async UniTask Play()
    {
        await Enter();
        await Loop();
        await Exit();
    }

    private async UniTask Enter()
    {
        var option = await IMainMenuFlow.Resolve().Play();
        switch (option)
        {
            case MainMenuOption.Continue:
                await IGameSystem.Resolve().ContinueGame();
                break;
            case MainMenuOption.NewGame:
                await IGameSystem.Resolve().NewGame();
                break;
        }
    }

    private async UniTask Loop()
    {
        while (true)
        {
            var entryName = IEntrySystem.Resolve().GetName();
            var encounterName = IEncounterSystem.Resolve().GetName();
            if (!string.IsNullOrEmpty(entryName))
                await IEntryFlow.Resolve().Play();
            else if (!string.IsNullOrEmpty(encounterName))
                await IEncounterFlow.Resolve().Play();
            else
                break;
            await UniTask.NextFrame();
        }
    }

    private async UniTask Exit()
    {
        IDataSystem.Resolve().Delete();
        await UniTask.CompletedTask;
    }
}
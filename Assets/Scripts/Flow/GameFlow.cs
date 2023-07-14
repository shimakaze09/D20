﻿using Cysharp.Threading.Tasks;

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
        await UniTask.CompletedTask;
    }

    private async UniTask Exit()
    {
        IDataSystem.Resolve().Delete();
        await UniTask.CompletedTask;
    }
}
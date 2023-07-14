using Cysharp.Threading.Tasks;

public interface IGameSystem : IDependency<IGameSystem>
{
    UniTask NewGame();
    UniTask ContinueGame();
}

public class GameSystem : IGameSystem
{
    public async UniTask NewGame()
    {
        var dataSystem = IDataSystem.Resolve();
        dataSystem.Create();
        await UniTask.CompletedTask;
    }

    public async UniTask ContinueGame()
    {
        IDataSystem.Resolve().Load();
        await UniTask.CompletedTask;
    }
}
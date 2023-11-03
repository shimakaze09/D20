using Cysharp.Threading.Tasks;

public interface ICombatFlow : IDependency<ICombatFlow>
{
    UniTask<CombatResult> Play();
}

public struct CombatFlow : ICombatFlow
{
    public async UniTask<CombatResult> Play()
    {
        await Enter();
        var result = await Loop();
        await Exit();
        return result;
    }

    private async UniTask Enter()
    {
        // TODO: initiative, surprise attacks, etc
        await UniTask.CompletedTask;
    }

    private async UniTask<CombatResult> Loop()
    {
        CombatResult? result = null;
        while (!result.HasValue)
            result = await IRoundFlow.Resolve().Play();
        return result.Value;
    }

    private async UniTask Exit()
    {
        // TODO: award experience, delete monster data, etc
        await UniTask.CompletedTask;
    }
}
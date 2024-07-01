#region

using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

#endregion

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
        // TODO: surprise attacks, etc
        var entities = new List<Entity>(ICombatantSystem.Resolve().Table);
        IRollInitiativeSystem.Resolve().Roll(entities);
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
        await UniTask.Delay(TimeSpan.FromSeconds(3));
    }
}
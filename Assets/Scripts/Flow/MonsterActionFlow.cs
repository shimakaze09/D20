using Cysharp.Threading.Tasks;

public interface IMonsterActionFlow : IDependency<IMonsterActionFlow>
{
    UniTask<CombatResult?> Play();
}

public class MonsterActionFlow : IMonsterActionFlow
{
    public async UniTask<CombatResult?> Play()
    {
        var current = ITurnSystem.Resolve().Current;
        ICombatSelectionIndicator.Resolve().Mark(current);
        var didAct = false;
        foreach (var actionName in current.EncounterActions.names)
        {
            var action = await ICombatActionAssetSystem.Resolve().Load(actionName);
            if (action.CanPerform(current) && current.HitPoints > 0)
            {
                await action.Perform(current);
                didAct = true;
                break;
            }
        }

        if (!didAct)
            ITurnSystem.Resolve().TakeAction(3, false);

        return ICombatResultSystem.Resolve().CheckResult();
    }
}
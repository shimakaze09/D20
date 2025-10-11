using Cysharp.Threading.Tasks;

public interface ICombatAction
{
    bool CanPerform(Entity entity);
    UniTask Perform(Entity entity);
}
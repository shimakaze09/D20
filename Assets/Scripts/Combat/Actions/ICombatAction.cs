#region

using Cysharp.Threading.Tasks;

#endregion

public interface ICombatAction
{
    bool CanPerform(Entity entity);
    UniTask Perform(Entity entity);
}
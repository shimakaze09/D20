#region

using Cysharp.Threading.Tasks;
using UnityEngine;

#endregion

public class CombatantView : MonoBehaviour
{
    public SpriteRenderer avatar;
    public SpriteRenderer shadow;
    public bool flipDirection;
}

public enum CombatantDirection
{
    Left,
    Right
}

public enum CombatantAnimation
{
    Attack,
    Death,
    Gesture,
    Idle,
    Walk
}

public interface ICombatantViewSystem : IDependency<ICombatantViewSystem>
{
    void SetLayerOrder(CombatantView view, int value);
    void SetAnimation(CombatantView view, CombatantAnimation animation);
    UniTask PlayAnimation(CombatantView view, CombatantAnimation animation);
}

public class CombatantViewSystem : ICombatantViewSystem
{
    private readonly int attackState = Animator.StringToHash("Attack");
    private readonly int deathState = Animator.StringToHash("Death");
    private readonly int gestureState = Animator.StringToHash("Gesture");
    private readonly int idleState = Animator.StringToHash("Idle");
    private readonly int walkState = Animator.StringToHash("Walk");

    public void SetLayerOrder(CombatantView view, int value)
    {
        view.shadow.sortingOrder = -value * 2;
        view.avatar.sortingOrder = -value * 2 + 1;
    }

    public void SetAnimation(CombatantView view, CombatantAnimation animation)
    {
        var hash = HashForState(animation);
        var animator = view.avatar.GetComponent<Animator>();
        animator.CrossFade(hash, 0);
    }

    public async UniTask PlayAnimation(CombatantView view, CombatantAnimation animation)
    {
        var hash = HashForState(animation);
        var animator = view.avatar.GetComponent<Animator>();
        animator.CrossFade(hash, 0);
        while (true)
        {
            await UniTask.NextFrame(animator.GetCancellationTokenOnDestroy());
            if (animator.GetCurrentAnimatorStateInfo(0).shortNameHash != hash)
                break;
        }
    }

    private int HashForState(CombatantAnimation animState)
    {
        switch (animState)
        {
            case CombatantAnimation.Attack:
                return attackState;
            case CombatantAnimation.Death:
                return deathState;
            case CombatantAnimation.Gesture:
                return gestureState;
            case CombatantAnimation.Idle:
                return idleState;
            case CombatantAnimation.Walk:
                return walkState;
            default:
                return 0;
        }
    }
}
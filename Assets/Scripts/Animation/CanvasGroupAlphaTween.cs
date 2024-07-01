#region

using UnityEngine;

#endregion

public class CanvasGroupAlphaTween : ScalarTween
{
    public CanvasGroup target;

    protected override void OnUpdate()
    {
        base.OnUpdate();
        target.alpha = currentTweenValue;
    }
}
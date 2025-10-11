using UnityEngine;

public class QuaternionTween : Tween
{
    public Quaternion endTweenValue;
    public Quaternion startTweenValue;
    public Quaternion currentTweenValue { get; private set; }

    protected override void OnUpdate()
    {
        currentTweenValue = Quaternion.SlerpUnclamped(startTweenValue, endTweenValue, currentValue);
        base.OnUpdate();
    }
}
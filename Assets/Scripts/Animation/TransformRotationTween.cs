#region

using UnityEngine;

#endregion

public class TransformRotationTween : QuaternionTween
{
    public Transform transform;

    protected override void OnUpdate()
    {
        base.OnUpdate();
        transform.rotation = currentTweenValue;
    }
}
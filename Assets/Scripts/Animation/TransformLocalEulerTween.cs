﻿#region

using UnityEngine;

#endregion

public class TransformLocalEulerTween : Vector3Tween
{
    public Transform transform;

    protected override void OnUpdate()
    {
        base.OnUpdate();
        transform.localEulerAngles = currentTweenValue;
    }
}
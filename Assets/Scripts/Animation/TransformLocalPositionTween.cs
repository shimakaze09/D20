﻿#region

using UnityEngine;

#endregion

public class TransformLocalPositionTween : Vector3Tween
{
    public Transform transform;

    protected override void OnUpdate()
    {
        base.OnUpdate();
        transform.localPosition = currentTweenValue;
    }
}
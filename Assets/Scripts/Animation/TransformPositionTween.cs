﻿#region

using UnityEngine;

#endregion

public class TransformPositionTween : Vector3Tween
{
    public Transform transform;

    protected override void OnUpdate()
    {
        base.OnUpdate();
        transform.position = currentTweenValue;
    }
}
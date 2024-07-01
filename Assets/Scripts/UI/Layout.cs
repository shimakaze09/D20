#region

using System;
using UnityEngine;

#endregion

[Serializable]
public struct Layout
{
    public Anchor anchor;
    public Pivot pivot;
    public Vector2 position;
}

public static class RectTransformLayoutExtensions
{
    public static void SetLayout(this RectTransform rectTransform, Layout layout)
    {
        rectTransform.SetAnchor(layout.anchor);
        rectTransform.SetPivot(layout.pivot);
        rectTransform.anchoredPosition = layout.position;
    }
}
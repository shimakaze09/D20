#region

using UnityEngine;

#endregion

public class LayoutTween : Tween
{
    public Layout endLayout;
    public RectTransform rectTransform;
    public Layout startLayout;

    protected override void OnUpdate()
    {
        base.OnUpdate();
        rectTransform.anchorMin = Vector2.Lerp(startLayout.anchor.Min(), endLayout.anchor.Max(), currentValue);
        rectTransform.anchorMax = Vector2.Lerp(startLayout.anchor.Max(), endLayout.anchor.Max(), currentValue);
        rectTransform.pivot = Vector2.Lerp(startLayout.pivot.ToVector2(), endLayout.pivot.ToVector2(), currentValue);
        rectTransform.anchoredPosition = Vector2.Lerp(startLayout.position, endLayout.position, currentValue);
    }
}
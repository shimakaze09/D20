public class ScalarTween : Tween
{
    public float endTweenValue;
    public float startTweenValue;
    public float currentTweenValue { get; private set; }

    protected override void OnUpdate()
    {
        currentTweenValue = (endTweenValue - startTweenValue) * currentValue + startTweenValue;
        base.OnUpdate();
    }
}
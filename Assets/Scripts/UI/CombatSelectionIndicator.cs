using UnityEngine;

public interface ICombatSelectionIndicator : IDependency<ICombatSelectionIndicator>
{
    void SetPosition(Point value);
    void SetVisible(bool isVisible);
}

public class CombatSelectionIndicator : MonoBehaviour, ICombatSelectionIndicator
{
    private void OnEnable()
    {
        ICombatSelectionIndicator.Register(this);
    }

    private void OnDisable()
    {
        ICombatSelectionIndicator.Reset();
    }

    public void SetPosition(Point value)
    {
        transform.position = value;
    }

    public void SetVisible(bool isVisible)
    {
        GetComponent<SpriteRenderer>().enabled = isVisible;
    }
}
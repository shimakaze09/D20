#region

using UnityEngine;

#endregion

public interface ICombatSelectionIndicator : IDependency<ICombatSelectionIndicator>
{
    void SetPosition(Point value);
    void SetSpace(int value);
    void Mark(Entity entity);
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

    public void SetSpace(int tiles)
    {
        transform.localScale = new Vector3(tiles, tiles, tiles);
    }

    public void Mark(Entity entity)
    {
        SetPosition(entity.Position);
        SetSpace(entity.Size.ToTiles());
    }

    public void SetVisible(bool isVisible)
    {
        GetComponent<SpriteRenderer>().enabled = isVisible;
    }
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public interface IBoardHighlightSystem : IDependency<IBoardHighlightSystem>
{
    void Highlight(IEnumerable<Point> points, Color color);
    void ClearHighlights();
}

public class BoardHighlightSystem : MonoBehaviour, IBoardHighlightSystem
{
    [SerializeField] private TileBase highlight;
    private Tilemap tilemap;

    private void OnEnable()
    {
        tilemap = GetComponent<Tilemap>();
        IBoardHighlightSystem.Register(this);
    }

    private void OnDisable()
    {
        IBoardHighlightSystem.Reset();
    }

    public void Highlight(IEnumerable<Point> points, Color color)
    {
        ClearHighlights();
        foreach (var point in points)
            tilemap.SetTile(new Vector3Int(point.x, point.y, 0), highlight);
        tilemap.color = color;
    }

    public void ClearHighlights()
    {
        tilemap.ClearAllTiles();
        tilemap.color = Color.white;
    }
}
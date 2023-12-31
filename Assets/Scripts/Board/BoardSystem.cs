using UnityEngine;
using UnityEngine.Tilemaps;

public interface IBoardSystem : IDependency<IBoardSystem>
{
    BoardData BoardData { get; }
    void Load(IEncounter encounter);
    TileBase GetTile(Point point);
}

public class BoardSystem : MonoBehaviour, IBoardSystem
{
    public BoardData BoardData { get; private set; }
    Tilemap tilemap;

    public void Load(IEncounter encounter)
    {
        BoardData = encounter.BoardData;
        encounter.BoardSkin.Load(tilemap, BoardData);
    }

    public TileBase GetTile(Point point)
    {
        return tilemap.GetTile(new Vector3Int(point.x, point.y, 0));
    }

    private void OnEnable()
    {
        tilemap = GetComponent<Tilemap>();
        IBoardSystem.Register(this);
    }

    private void OnDisable()
    {
        IBoardSystem.Reset();
    }
}
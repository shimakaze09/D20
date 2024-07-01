#region

using UnityEngine;
using UnityEngine.Tilemaps;

#endregion

public interface IBoardSystem : IDependency<IBoardSystem>
{
    BoardData BoardData { get; }
    void Load(IEncounter encounter);
    TileBase GetTile(Point point);
    bool IsPointOnBoard(Point point);
    int GetTileType(Point point);
}

public class BoardSystem : MonoBehaviour, IBoardSystem
{
    private Tilemap tilemap;

    private void OnEnable()
    {
        tilemap = GetComponent<Tilemap>();
        IBoardSystem.Register(this);
    }

    private void OnDisable()
    {
        IBoardSystem.Reset();
    }

    public BoardData BoardData { get; private set; }

    public void Load(IEncounter encounter)
    {
        BoardData = encounter.BoardData;
        encounter.BoardSkin.Load(tilemap, BoardData);
    }

    public TileBase GetTile(Point point)
    {
        return tilemap.GetTile(new Vector3Int(point.x, point.y, 0));
    }

    public bool IsPointOnBoard(Point point)
    {
        return point.x >= 0 && point.y >= 0 &&
               point.x < BoardData.width && point.y < BoardData.height;
    }

    public int GetTileType(Point point)
    {
        var index = point.y * BoardData.width + point.x;
        return BoardData.tiles[index];
    }
}
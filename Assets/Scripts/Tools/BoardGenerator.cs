using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField] private BoardData data;
    [SerializeField] private int width = 6;
    [SerializeField] private int height = 8;
    [SerializeField] private int[] tiles;

    [SerializeField] private TileBase[] tileViews;
    [SerializeField] private float[] elevations = { 0.3f, 0.6f, 0.7f, 1f };

    [SerializeField] private Vector2 perlinScale = new(0.1f, 0.1f);
    [SerializeField] private Vector2 perlinOffset = Vector2.zero;

    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Transform marker;
    [SerializeField] private Point markerPosition;

    public void Clear()
    {
        tiles = null;
        tilemap.ClearAllTiles();
    }

    public void Generate()
    {
        Clear();
        tiles = new int[width * height];
        for (var y = 0; y < height; ++y)
        for (var x = 0; x < width; ++x)
            tilemap.SetTile(new Vector3Int(x, y, 0), tileViews[0]);
    }

    public void GeneratePerlin()
    {
        Clear();
        tiles = new int[width * height];
        for (var y = 0; y < height; ++y)
        for (var x = 0; x < width; ++x)
        {
            var xPos = x * perlinScale.x + perlinOffset.x;
            var yPos = y * perlinScale.y + perlinOffset.y;
            var elevation = Mathf.PerlinNoise(xPos, yPos);
            var tileIndex = IndexForElevation(elevation);
            var tileView = tileViews[tileIndex];
            tilemap.SetTile(new Vector3Int(x, y, 0), tileView);
            tiles[y * width + x] = tileIndex;
        }
    }

    public void Grow()
    {
        var index = markerPosition.y * width + markerPosition.x;
        tiles[index] = Mathf.Min(tiles[index] + 1, elevations.Length - 1);
        RefreshTile(index);
    }

    public void Shrink()
    {
        var index = markerPosition.y * width + markerPosition.x;
        tiles[index] = Mathf.Max(tiles[index] - 1, 0);
        RefreshTile(index);
    }

    public void MoveMarker(Point offset)
    {
        markerPosition += offset;
        UpdateMarker();
    }

    public void SnapMarker()
    {
        markerPosition = new Point
        {
            x = Mathf.RoundToInt(marker.transform.position.x),
            y = Mathf.RoundToInt(marker.transform.position.y)
        };
        UpdateMarker();
    }

    public void UpdateMarker()
    {
        marker.position = markerPosition;
    }

    public void Save()
    {
        if (data == null)
        {
            Debug.LogError("Missing board data - must assign first");
            return;
        }

        Undo.RecordObject(data, "Saved Board");
        data.width = width;
        data.height = height;
        data.tiles = new int[tiles.Length];
        Array.Copy(tiles, data.tiles, tiles.Length);

        EditorUtility.SetDirty(data);
    }

    public void Load()
    {
        Clear();

        if (data == null)
        {
            Debug.LogError("Missing board data - must assign first");
            return;
        }

        width = data.width;
        height = data.height;
        tiles = new int[data.tiles.Length];
        Array.Copy(data.tiles, tiles, data.tiles.Length);

        RefreshBoard();
    }

    private void RefreshBoard()
    {
        for (var i = 0; i < tiles.Length; ++i)
            RefreshTile(i);
    }

    private void RefreshTile(int index)
    {
        var x = index % width;
        var y = index / width;
        var tileView = tileViews[tiles[index]];
        tilemap.SetTile(new Vector3Int(x, y, 0), tileView);
    }

    private int IndexForElevation(float value)
    {
        for (var index = 0; index < elevations.Length; ++index)
            if (value < elevations[index])
                return index;
        return elevations.Length - 1;
    }
}
using UnityEngine;

[CreateAssetMenu]
public class BoardData : ScriptableObject
{
    public int width;
    public int height;
    public int[] tiles;
}
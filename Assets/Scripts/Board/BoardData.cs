#region

using UnityEngine;

#endregion

[CreateAssetMenu]
public class BoardData : ScriptableObject
{
    public int width;
    public int height;
    public int[] tiles;
}
using UnityEngine;

[CreateAssetMenu]
public class BoardData : ScriptableObject
{
    public int height;
    public int[] tiles;
    public int width;

    [field: SerializeField] public int SomeNumber { get; private set; } = 5;
}
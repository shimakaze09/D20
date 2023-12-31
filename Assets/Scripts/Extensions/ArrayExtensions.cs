public static class ArrayExtensions
{
    public static T Random<T>(this T[] array)
    {
        var index = UnityEngine.Random.Range(0, array.Length);
        return array[index];
    }
}
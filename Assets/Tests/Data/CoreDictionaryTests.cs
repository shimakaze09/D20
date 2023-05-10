using NUnit.Framework;
using UnityEngine;

public class CoreDictionaryTests
{
    private const string json = "{\"keys\":[1],\"values\":[3]}";
    private const int key = 1;
    private const int value = 3;

    [Test]
    public void Add_And_Remove_Success()
    {
        var sut = new CoreDictionary<int, int>();
        sut.Add(key, value);
        Assert.AreEqual(1, sut.Count);
        Assert.AreEqual(value, sut[key]);

        sut.Remove(key);
        Assert.IsEmpty(sut);
    }

    [Test]
    public void JsonUtility_Serialization_Success()
    {
        var sut = new CoreDictionary<int, int>();
        sut.Add(key, value);
        var result = JsonUtility.ToJson(sut);
        Assert.AreEqual(json, result);
    }

    [Test]
    public void JsonUtility_Deserialization_Success()
    {
        var sut = new CoreDictionary<int, int>();
        JsonUtility.FromJsonOverwrite(json, sut);
        Assert.AreEqual(1, sut.Count);
        Assert.AreEqual(value, sut[key]);
    }
}
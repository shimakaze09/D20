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
        CoreDictionary<int, int> sut = new();
        sut.Add(key, value);
        Assert.AreEqual(1, sut.Count);
        Assert.AreEqual(value, sut[key]);

        sut.Remove(key);
        Assert.IsEmpty(sut);
    }

    [Test]
    public void JsonUtility_Serialization_Success()
    {
        CoreDictionary<int, int> sut = new();
        sut.Add(key, value);
        var result = JsonUtility.ToJson(sut);
        Assert.AreEqual(json, result);
    }

    [Test]
    public void JsonUtility_Deserialization_Success()
    {
        CoreDictionary<int, int> sut = new();
        JsonUtility.FromJsonOverwrite(json, sut);
        Assert.AreEqual(1, sut.Count);
        Assert.AreEqual(value, sut[key]);
    }

    [Test]
    public void JsonUtility_SerializableEntity_Success()
    {
        var entity = new Entity(123);
        var sut = new CoreDictionary<Entity, int>();
        sut.Add(entity, 42);
        var json = JsonUtility.ToJson(sut);
        JsonUtility.FromJsonOverwrite(json, sut);
        Assert.True(sut.ContainsKey(entity));
        Assert.AreEqual(42, sut[entity]);
    }
}
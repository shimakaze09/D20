#region

using NUnit.Framework;
using UnityEngine;

#endregion

public class AbilityScoreProviderTests
{
    [SetUp]
    public void SetUp()
    {
        IDataSystem.Register(new MockDataSystem());
        IDataSystem.Resolve().Create();
        AbilityScoreInjector.Inject();
    }

    [Test]
    public void AbilityScoreProviderTestsSimplePasses()
    {
        // Arrange
        var asset = new GameObject("Hero");
        var provider = asset.AddComponent<AbilityScoreProvider>();
        var json = "{\"attribute\":1,\"value\":12}";
        JsonUtility.FromJsonOverwrite(json, provider);
        var entity = new Entity(123);

        // Act
        provider.Setup(entity);

        // Assert
        Assert.AreEqual(12, entity.Dexterity.value);
    }
}
using NUnit.Framework;
using UnityEngine;

public class EntityRecipeSystemTests
{
    private MockAssetManager<GameObject> mockAssetManager;

    [SetUp]
    public void SetUp()
    {
        IDataSystem.Register(new MockDataSystem());
        IDataSystem.Resolve().Create();
        IEntitySystem.Register(new EntitySystem());
        IRandomNumberGenerator.Register(new RandomNumberGenerator());
        mockAssetManager = new MockAssetManager<GameObject>();
        IAssetManager<GameObject>.Register(mockAssetManager);
    }

    [Test]
    public async void EntityRecipeSystemTestsSimplePasses()
    {
        // Arrange
        var hero = new GameObject("Hero");
        var provider1 = hero.AddComponent<MockAttributeProvider>();
        var provider2 = hero.AddComponent<MockAttributeProvider>();
        mockAssetManager.fakeAsset = hero;
        var sut = new EntityRecipeSystem();

        // Act
        var entity = await sut.Create("Hero");

        // Assert
        Assert.IsTrue(provider1.DidSetup);
        Assert.AreEqual(entity, provider1.SetupEntity);
        Assert.IsTrue(provider2.DidSetup);
        Assert.AreEqual(entity, provider2.SetupEntity);
    }
}
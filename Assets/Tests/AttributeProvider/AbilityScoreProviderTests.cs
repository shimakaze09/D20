using NUnit.Framework;
using UnityEngine;

public class AbilityScoreProviderTests
{
    [SetUp]
    public void SetUp()
    {
        IDataSystem.Register(new MockDataSystem());
        IDataSystem.Resolve().Create();
        IAbilityScoreSystem.Register(new AbilityScoreSystem());
        ICharismaSystem.Register(new CharismaSystem());
        IConstitutionSystem.Register(new ConstitutionSystem());
        IDexteritySystem.Register(new DexteritySystem());
        IIntelligenceSystem.Register(new IntelligenceSystem());
        IStrengthSystem.Register(new StrengthSystem());
        IWisdomSystem.Register(new WisdomSystem());
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
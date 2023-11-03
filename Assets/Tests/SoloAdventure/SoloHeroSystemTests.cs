using NUnit.Framework;
using UnityEngine;

public class SoloHeroSystemTests
{
    private MockEntityRecipeSystem mockEntityRecipeSystem;

    [SetUp]
    public void SetUp()
    {
        IDataSystem.Register(new MockDataSystem());
        IDataSystem.Resolve().Create();
        AbilityScoreInjector.Inject();
        SkillsInjector.Inject();
        ILevelSystem.Register(new LevelSystem());
        mockEntityRecipeSystem = new MockEntityRecipeSystem();
        IEntityRecipeSystem.Register(mockEntityRecipeSystem);
    }

    [Test]
    public async void SoloHeroSystemTestsSimplePasses()
    {
        // Arrange
        mockEntityRecipeSystem.fakeEntity = CreateSoloHero();
        var sut = new SoloHeroSystem();

        // Act
        await sut.CreateHero();

        // Assert
        Assert.AreEqual(7,
            sut.Hero.Athletics); // (+4 str, +2 trained, +1 level)
    }

    private Entity CreateSoloHero()
    {
        var result = new Entity(123);
        result.Level = 1;
        result.Strength = 18;
        IProficiencySystem.Resolve()
            .Set(result, Skill.Athletics, Proficiency.Trained);
        return result;
    }
}
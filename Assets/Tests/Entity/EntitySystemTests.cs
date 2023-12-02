using NUnit.Framework;

public class EntitySystemTests
{
    private MockDataSystem mockDataSystem = new();
    private EntitySystem sut = new();

    [SetUp]
    public void SetUp()
    {
        IDataSystem.Register(mockDataSystem);
        mockDataSystem.Create();
    }

    [TearDown]
    public void TearDown()
    {
        IRandomNumberGenerator.Reset();
        IDataSystem.Reset();
    }

    [Test]
    public void Create_Succeeds()
    {
        IRandomNumberGenerator.Register(new MockFixedRNG(1));

        var entity = sut.Create();

        Assert.AreEqual(1, entity.id);
        Assert.True(mockDataSystem.Data.entities.Contains(entity));
    }

    [Test]
    public void Create_ZeroId_RollsAgain()
    {
        IRandomNumberGenerator.Register(new MockSequenceRNG(0, 1));

        var entity = sut.Create();

        Assert.AreEqual(1, entity.id);
    }

    [Test]
    public void Create_DuplicateId_RollsAgain()
    {
        IRandomNumberGenerator.Register(new MockSequenceRNG(1, 2));
        mockDataSystem.Data.entities.Add(new Entity(1));

        var entity = sut.Create();

        Assert.AreEqual(2, entity.id);
    }

    [Test]
    public void Destroy_Succeeds()
    {
        var entity = new Entity(1);
        mockDataSystem.Data.entities.Add(entity);

        sut.Destroy(entity);

        Assert.IsFalse(mockDataSystem.Data.entities.Contains(entity));
    }
}
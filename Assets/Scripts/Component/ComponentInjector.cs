public static class ComponentInjector
{
    public static void Inject()
    {
        AbilityScoreInjector.Inject();
        IAdventureItemSystem.Register(new AdventureItemSystem());
        IArmorClassSystem.Register(new ArmorClassSystem());
        ICombatantSystem.Register(new CombatantSystem());
        IDyingSystem.Register(new DyingSystem());
        HealthInjector.Inject();
        ILevelSystem.Register(new LevelSystem());
        INameSystem.Register(new NameSystem());
        IPartySystem.Register(new PartySystem());
        IPositionSystem.Register(new PositionSystem());
        SkillsInjector.Inject();
    }

    public static void SetUp()
    {
        AbilityScoreInjector.SetUp();
        IAdventureItemSystem.Resolve().SetUp();
        IArmorClassSystem.Resolve().SetUp();
        ICombatantSystem.Resolve().SetUp();
        IDyingSystem.Resolve().SetUp();
        HealthInjector.SetUp();
        ILevelSystem.Resolve().SetUp();
        INameSystem.Resolve().SetUp();
        IPartySystem.Resolve().SetUp();
        IPositionSystem.Resolve().SetUp();
        SkillsInjector.SetUp();
    }

    public static void TearDown()
    {
        AbilityScoreInjector.TearDown();
        IAdventureItemSystem.Resolve().TearDown();
        IArmorClassSystem.Resolve().TearDown();
        ICombatantSystem.Resolve().TearDown();
        IDyingSystem.Resolve().TearDown();
        HealthInjector.TearDown();
        ILevelSystem.Resolve().TearDown();
        INameSystem.Resolve().TearDown();
        IPartySystem.Resolve().TearDown();
        IPositionSystem.Resolve().TearDown();
        SkillsInjector.TearDown();
    }
}
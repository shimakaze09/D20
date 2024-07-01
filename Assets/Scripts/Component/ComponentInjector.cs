public static class ComponentInjector
{
    public static void Inject()
    {
        AbilityScoreInjector.Inject();
        IAdventureItemSystem.Register(new AdventureItemSystem());
        IAncestrySystem.Register(new AncestrySystem());
        IArmorClassSystem.Register(new ArmorClassSystem());
        IBackgroundSystem.Register(new BackgroundSystem());
        ICombatantSystem.Register(new CombatantSystem());
        IDyingSystem.Register(new DyingSystem());
        IEntityFilterSystem.Register(new EntityFilterSystem());
        HealthInjector.Inject();
        IInitiativeSystem.Register(new InitiativeSystem());
        ILevelSystem.Register(new LevelSystem());
        INameSystem.Register(new NameSystem());
        IPartyOrderSystem.Register(new PartyOrderSystem());
        IPartySystem.Register(new PartySystem());
        PerceptionInjector.Inject();
        IPositionSystem.Register(new PositionSystem());
        IRaritySystem.Register(new RaritySystem());
        SavingThrowsInjector.Inject();
        SizeInjector.Inject();
        SkillsInjector.Inject();
        ISpeedSystem.Register(new SpeedSystem());
        WeaponInjector.Inject();
    }
}
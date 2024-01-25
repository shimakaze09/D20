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
        ISpeedSystem.Register(new SpeedSystem());
    }
}
public static class ComponentInjector
{
    public static void Inject()
    {
        AbilityScoreInjector.Inject();
        IAdventureItemSystem.Register(new AdventureItemSystem());
        IAncestrySystem.Register(new AncestrySystem());
        IArmorClassSystem.Register(new ArmorClassSystem());
        ICombatantSystem.Register(new CombatantSystem());
        IDyingSystem.Register(new DyingSystem());
        IEntityFilterSystem.Register(new EntityFilterSystem());
        HealthInjector.Inject();
        ILevelSystem.Register(new LevelSystem());
        INameSystem.Register(new NameSystem());
        IPartyOrderSystem.Register(new PartyOrderSystem());
        IPartySystem.Register(new PartySystem());
        IPositionSystem.Register(new PositionSystem());
        IRaritySystem.Register(new RaritySystem());
        SizeInjector.Inject();
        SkillsInjector.Inject();
        ISpeedSystem.Register(new SpeedSystem());
    }
}
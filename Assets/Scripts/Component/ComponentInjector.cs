public static class ComponentInjector
{
    public static void Inject()
    {
        AbilityScoreInjector.Inject();
        IAdventureItemSystem.Register(new AdventureItemSystem());
        ICombatantSystem.Register(new CombatantSystem());
        ILevelSystem.Register(new LevelSystem());
        INameSystem.Register(new NameSystem());
        IPartySystem.Register(new PartySystem());
        IPositionSystem.Register(new PositionSystem());
        SkillsInjector.Inject();
    }
}
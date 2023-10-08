public static class ComponentInjector
{
    public static void Inject()
    {
        AbilityScoreInjector.Inject();
        IAdventureItemSystem.Register(new AdventureItemSystem());
        INameSystem.Register(new NameSystem());
        ILevelSystem.Register(new LevelSystem());
        SkillsInjector.Inject();
    }
}
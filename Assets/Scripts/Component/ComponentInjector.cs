public static class ComponentInjector
{
    public static void Inject()
    {
        AbilityScoreInjector.Inject();
        INameSystem.Register(new NameSystem());
        IAdventureItemSystem.Register(new AdventureItemSystem());
    }
}
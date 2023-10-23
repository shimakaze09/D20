public static class FlowInjector
{
    public static void Inject()
    {
        IEncounterFlow.Register(new EncounterFlow());
        IEntryFlow.Register(new EntryFlow());
        IGameFlow.Register(new GameFlow());
        IHeroActionFlow.Register(new HeroActionFlow());
        IMainMenuFlow.Register(new MainMenuFlow());
    }
}
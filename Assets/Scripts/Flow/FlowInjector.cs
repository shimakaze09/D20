public static class FlowInjector
{
    public static void Inject()
    {
        IMainMenuFlow.Register(new MainMenuFlow());
        IGameFlow.Register(new GameFlow());
        IEntryFlow.Register(new EntryFlow());
    }
}
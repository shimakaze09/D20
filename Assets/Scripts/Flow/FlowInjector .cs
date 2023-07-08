public static class FlowInjector
{
    public static void Inject()
    {
        IMainMenuFlow.Register(new MainMenuFlow());
    }
}
public static class Injector
{
    public static void Inject()
    {
        ActionInjector.Inject();
        AssetManagerInjector.Inject();
        CombatInjector.Inject();
        ComponentInjector.Inject();
        DataInjector.Inject();
        DiceRollInjector.Inject();
        EntityInjector.Inject();
        FlowInjector.Inject();
        IGameSystem.Register(new GameSystem());
        IInputSystem.Register(new InputSystem());
        SoloAdventureInjector.Inject();
    }
}
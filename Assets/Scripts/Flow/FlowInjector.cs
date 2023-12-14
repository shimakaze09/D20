public static class FlowInjector
{
    public static void Inject()
    {
        ICombatFlow.Register(new CombatFlow());
        IEncounterFlow.Register(new EncounterFlow());
        IEntryFlow.Register(new EntryFlow());
        IGameFlow.Register(new GameFlow());
        IHeroActionFlow.Register(new HeroActionFlow());
        IMainMenuFlow.Register(new MainMenuFlow());
        IMonsterActionFlow.Register(new MonsterActionFlow());
        IRoundFlow.Register(new RoundFlow());
        ITurnFlow.Register(new TurnFlow());
    }

    public static void SetUp()
    {
        ICombatFlow.Resolve().SetUp();
        IEncounterFlow.Resolve().SetUp();
        IEntryFlow.Resolve().SetUp();
        IGameFlow.Resolve().SetUp();
        IHeroActionFlow.Resolve().SetUp();
        IMainMenuFlow.Resolve().SetUp();
        IMonsterActionFlow.Resolve().SetUp();
        IRoundFlow.Resolve().SetUp();
        ITurnFlow.Resolve().SetUp();
    }

    public static void TearDown()
    {
        ICombatFlow.Resolve().TearDown();
        IEncounterFlow.Resolve().TearDown();
        IEntryFlow.Resolve().TearDown();
        IGameFlow.Resolve().TearDown();
        IHeroActionFlow.Resolve().TearDown();
        IMainMenuFlow.Resolve().TearDown();
        IMonsterActionFlow.Resolve().TearDown();
        IRoundFlow.Resolve().TearDown();
        ITurnFlow.Resolve().TearDown();
    }
}
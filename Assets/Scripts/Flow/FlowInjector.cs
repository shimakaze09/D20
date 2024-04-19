public static class FlowInjector
{
    public static void Inject()
    {
        ICombatFlow.Register(new CombatFlow());
        ICreateHeroPartyFlow.Register(new CreateHeroPartyFlow());
        IEncounterFlow.Register(new EncounterFlow());
        IEntryFlow.Register(new EntryFlow());
        IGameFlow.Register(new GameFlow());
        IHeroActionFlow.Register(new HeroActionFlow());
        IMainMenuFlow.Register(new MainMenuFlow());
        IMonsterActionFlow.Register(new MonsterActionFlow());
        IRoundFlow.Register(new RoundFlow());
        ITurnFlow.Register(new TurnFlow());
    }
}
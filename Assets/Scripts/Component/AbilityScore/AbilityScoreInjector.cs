public static class AbilityScoreInjector
{
    public static void Inject()
    {
        IAbilityScoreSystem.Register(new AbilityScoreSystem());
        ICharismaSystem.Register(new CharismaSystem());
        IConstitutionSystem.Register(new ConstitutionSystem());
        IDexteritySystem.Register(new DexteritySystem());
        IIntelligenceSystem.Register(new IntelligenceSystem());
        IStrengthSystem.Register(new StrengthSystem());
        IWisdomSystem.Register(new WisdomSystem());
    }

    public static void SetUp()
    {
        IAbilityScoreSystem.Resolve().SetUp();
        ICharismaSystem.Resolve().SetUp();
        IConstitutionSystem.Resolve().SetUp();
        IDexteritySystem.Resolve().SetUp();
        IIntelligenceSystem.Resolve().SetUp();
        IStrengthSystem.Resolve().SetUp();
        IWisdomSystem.Resolve().SetUp();
    }

    public static void TearDown()
    {
        IAbilityScoreSystem.Resolve().TearDown();
        ICharismaSystem.Resolve().TearDown();
        IConstitutionSystem.Resolve().TearDown();
        IDexteritySystem.Resolve().TearDown();
        IIntelligenceSystem.Resolve().TearDown();
        IStrengthSystem.Resolve().TearDown();
        IWisdomSystem.Resolve().TearDown();
    }
}
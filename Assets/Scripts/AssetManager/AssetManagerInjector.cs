public static class AssetManagerInjector
{
    public static void Inject()
    {
        IAncestryAssetSystem.Register(new AncestryAssetSystem());
        IBackgroundAssetSystem.Register(new BackgroundAssetSystem());
        ICombatActionAssetSystem.Register(new CombatActionAssetSystem());
        IEncounterAssetSystem.Register(new EncounterAssetSystem());
        IEntryAssetSystem.Register(new EntryAssetSystem());
        IWeaponAssetSystem.Register(new WeaponAssetSystem());
    }
}
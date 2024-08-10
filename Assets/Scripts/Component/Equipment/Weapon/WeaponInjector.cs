public static class WeaponInjector
{
    public static void Inject()
    {
        IWeaponCategorySystem.Register(new WeaponCategorySystem());
        IWeaponFilterSystem.Register(new WeaponFilterSystem());
        IWeaponGroupSystem.Register(new WeaponGroupSystem());
        IWeaponProficiencySystem.Register(new WeaponProficiencySystem());
        IWeaponTypeSystem.Register(new WeaponTypeSystem());
    }
}
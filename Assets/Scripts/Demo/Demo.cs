using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField] private GameObject heroCombatant;

    private void Start()
    {
        AssociateHero();
        new SomeOtherClass().DamageHero();
    }

    private void AssociateHero()
    {
        var hero = ISoloHeroSystem.Resolve().Hero;
        hero.SetView(heroCombatant, ViewZone.Combatant);
    }
}

public class SomeOtherClass
{
    public void DamageHero()
    {
        var hero = ISoloHeroSystem.Resolve().Hero;
        var view = hero.GetView(ViewZone.Combatant);
        var slider = view.GetComponentInChildren<CombatantUI>().healthSlider;
        slider.value = 0.5f;
    }
}
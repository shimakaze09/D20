using UnityEngine;

public class CombatantAssetProvider : MonoBehaviour, IAttributeProvider
{
    [SerializeField] private string value;

    public void Setup(Entity entity)
    {
        entity.CombatantAsset = value;
    }
}

using UnityEngine;

public class PartyProvider : MonoBehaviour, IAttributeProvider
{
    [SerializeField] private Party party;

    public void Setup(Entity entity)
    {
        entity.Party = party;
    }
}
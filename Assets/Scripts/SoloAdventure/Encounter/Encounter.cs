using UnityEngine;

public interface IEncounter
{
    string VictoryEntry { get; }
    string DefeatEntry { get; }
}

public class Encounter : MonoBehaviour, IEncounter
{
    public string VictoryEntry => victoryEntry;
    [SerializeField] private string victoryEntry;

    public string DefeatEntry => defeatEntry;
    [SerializeField] private string defeatEntry;
}
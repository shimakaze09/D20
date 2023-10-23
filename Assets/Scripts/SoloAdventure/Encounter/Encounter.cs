using UnityEngine;

public interface IEncounter
{
    string VictoryEntry { get; }
    string DefeatEntry { get; }
}

public class Encounter : MonoBehaviour, IEncounter
{
    public string VictoryEntry { get { return victoryEntry; } }
    [SerializeField] private string victoryEntry;

    public string DefeatEntry { get { return defeatEntry; } }
    [SerializeField] private string defeatEntry;
}
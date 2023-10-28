using UnityEngine;

public class SkillExploreEntryOption : MonoBehaviour, IEntryOption
{
    [SerializeField] private string text;
    [SerializeField] private Skill skill;
    [SerializeField] private int difficultyCheck;
    [SerializeField] private string criticalFailureEntry;
    [SerializeField] private string failureEntry;
    [SerializeField] private string successEntry;
    [SerializeField] private string criticalSuccessEntry;

    public string Text => text;

    public void Select()
    {
        var hero = ISoloHeroSystem.Resolve().Hero;
        var modifier = hero[skill];
        var result = ICheckSystem.Resolve()
            .GetResult(modifier, difficultyCheck);
        var entry = GetEntry(result);
        IEntrySystem.Resolve().SetName(entry);
    }

    private string GetEntry(Check result)
    {
        switch (result)
        {
            case Check.CriticalFailure:
                return criticalFailureEntry;
            case Check.Failure:
                return failureEntry;
            case Check.Success:
                return successEntry;
            default: // case Check.CriticalSuccess:
                return criticalSuccessEntry;
        }
    }
}
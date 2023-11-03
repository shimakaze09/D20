public class MockBaseSkillSystem : BaseSkillSystem
{
    private CoreDictionary<Entity, int> fakeTable = new();
    private Skill fakeSkill;
    private AbilityScore.Attribute fakeAttribute;

    public MockBaseSkillSystem(Skill fakeSkill,
        AbilityScore.Attribute fakeAttribute)
    {
        this.fakeSkill = fakeSkill;
        this.fakeAttribute = fakeAttribute;
    }

    public override CoreDictionary<Entity, int> Table => fakeTable;
    protected override Skill Skill => fakeSkill;
    protected override AbilityScore.Attribute Attribute => fakeAttribute;
}
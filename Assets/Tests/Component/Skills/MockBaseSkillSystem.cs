public class MockBaseSkillSystem : BaseSkillSystem
{
    private readonly AbilityScore.Attribute fakeAttribute;
    private readonly Skill fakeSkill;
    private readonly CoreDictionary<Entity, int> fakeTable = new();

    public MockBaseSkillSystem(Skill fakeSkill, AbilityScore.Attribute fakeAttribute)
    {
        this.fakeSkill = fakeSkill;
        this.fakeAttribute = fakeAttribute;
    }

    public override CoreDictionary<Entity, int> Table => fakeTable;
    protected override Skill Skill => fakeSkill;
    protected override AbilityScore.Attribute Attribute => fakeAttribute;
}
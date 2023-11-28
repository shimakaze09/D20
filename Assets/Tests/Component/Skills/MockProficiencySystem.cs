using System.Collections.Generic;

public class MockProficiencySystem : IProficiencySystem
{
    private Dictionary<Entity, Dictionary<Skill, Proficiency>> fakeTable = new();

    public Proficiency Get(Entity entity, Skill skill)
    {
        if (fakeTable.ContainsKey(entity))
        {
            var map = fakeTable[entity];
            if (map.ContainsKey(skill))
                return map[skill];
        }
        return 0;
    }

    public void Set(Entity entity, Skill skill, Proficiency value)
    {
        if (!fakeTable.ContainsKey(entity))
            fakeTable[entity] = new Dictionary<Skill, Proficiency>();

        fakeTable[entity][skill] = value;
    }
}
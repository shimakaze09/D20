using System.Collections.Generic;

public class MockSequenceRNG : IRandomNumberGenerator
{
    public int fallback;
    public Queue<int> values;

    public MockSequenceRNG(params int[] values)
    {
        this.values = new Queue<int>(values);
        fallback = 0;
    }

    public int Range(int minInclusive, int maxExclusive)
    {
        if (values.Count > 0)
            return values.Dequeue();
        return fallback;
    }
}
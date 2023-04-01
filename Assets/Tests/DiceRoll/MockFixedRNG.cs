using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockFixedRNG : IRandomNumberGenerator
{
    public int fakeOutput;

    public MockFixedRNG(int output)
    {
        fakeOutput = output;
    }

    public int Range(int minInclusive, int maxExclusive)
    {
        return fakeOutput;
    }
}
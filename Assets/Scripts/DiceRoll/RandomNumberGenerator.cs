using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRandomNumberGenerator : IDependency<IRandomNumberGenerator>
{
    public int Range(int minInclusive, int maxExclusive);
}

public class RandomNumberGenerator : IRandomNumberGenerator
{
    public int Range(int minInclusive, int maxExclusive)
    {
        return Random.Range(minInclusive, maxExclusive);
    }
}
#region

using System;
using Cysharp.Threading.Tasks;

#endregion

public interface IAttributeProvider
{
    void Setup(Entity entity)
    {
        throw new NotImplementedException();
    }

    async UniTask SetupFlow(Entity entity)
    {
        Setup(entity);
        await UniTask.CompletedTask;
    }
}
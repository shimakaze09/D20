using UnityEngine;
using Cysharp.Threading.Tasks;

public class AppFlow : MonoBehaviour
{
    private async UniTaskVoid Start()
    {
        DontDestroyOnLoad(gameObject);
        Injector.Inject();
        ISetUpSystem.Resolve().SetUp();
        while (true)
        {
            await IGameFlow.Resolve().Play();
            await UniTask.NextFrame(this.GetCancellationTokenOnDestroy());
        }
    }

    private void OnDestroy()
    {
        ITearDownSystem.Resolve().TearDown();
    }
}
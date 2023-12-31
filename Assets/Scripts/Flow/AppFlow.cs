using Cysharp.Threading.Tasks;
using UnityEngine;

public class AppFlow : MonoBehaviour
{
    private async UniTaskVoid Start()
    {
        DontDestroyOnLoad(gameObject);
        Injector.Inject();
        Injector.SetUp();
        while (true)
        {
            await IGameFlow.Resolve().Play();
            await UniTask.NextFrame(this.GetCancellationTokenOnDestroy());
        }
    }

    private void OnDestroy()
    {
        Injector.TearDown();
    }
}
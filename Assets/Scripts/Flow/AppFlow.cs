using UnityEngine;
using Cysharp.Threading.Tasks;

public class AppFlow : MonoBehaviour
{
    private async UniTaskVoid Start()
    {
        DontDestroyOnLoad(gameObject);
        Injector.Inject();
        while (true)
        {
            await IGameFlow.Resolve().Play();
            await UniTask.NextFrame(this.GetCancellationTokenOnDestroy());
        }
    }
}
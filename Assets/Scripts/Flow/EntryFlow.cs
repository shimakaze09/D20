using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public interface IEntryFlow : IDependency<IEntryFlow>
{
    UniTask Play();
}

public class EntryFlow : IEntryFlow
{
    public async UniTask Play()
    {
        // MARK: - Enter
        await SceneManager.LoadSceneAsync("Explore");
        var entry = await IEntryAssetSystem.Resolve().Load();

        var panel = IEntryPanel.Resolve();
        panel.Setup(entry);

        await panel.TransitionIn();

        // MARK: - Loop
        while (true)
        {
            // Either select a menu option or interact with a link in the text
            var cts = new CancellationTokenSource();
            var (win, menu, link) = await UniTask.WhenAny(
                panel.SelectMenuOption(cts.Token),
                panel.SelectLink(cts.Token)
            );
            cts.Cancel();
            cts.Dispose();

            if (win == 0)
            {
                // Selected a menu option
                entry.Options[menu].Select();
                break;
            }

            // Selected a link in the text
            await entry.SelectLink(link);
        }

        // MARK: - Exit
        IDataSystem.Resolve().Save();
        await panel.TransitionOut();
    }
}
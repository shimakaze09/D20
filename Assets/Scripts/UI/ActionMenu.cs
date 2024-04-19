using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface IActionMenu : IDependency<IActionMenu>
{
    UniTask Setup();
    UniTask TransitionIn();
    UniTask<string> SelectMenuItem();
    UniTask TransitionOut();
}

public class ActionMenu : MonoBehaviour, IActionMenu
{
    [SerializeField] private RectTransform rootPanel;
    [SerializeField] private List<Button> buttons;
    [SerializeField] private Layout onScreen;
    [SerializeField] private Layout offScreen;
    private Entity entity;
    private int menuCount;
    private int selection;

    private void OnEnable()
    {
        IActionMenu.Register(this);
    }

    private void OnDisable()
    {
        IActionMenu.Reset();
    }

    public async UniTask Setup()
    {
        selection = 0;
        buttons[0].Select();
        entity = ITurnSystem.Resolve().Current;
        var pairs = buttons.Zip(entity.EncounterActions.names, (button, action) => (button, action));
        foreach (var pair in pairs)
        {
            var label = pair.button.GetComponentInChildren<TextMeshProUGUI>();
            label.text = pair.action;
        }

        menuCount = pairs.Count();
        await UniTask.CompletedTask;
    }

    public async UniTask TransitionIn()
    {
        await rootPanel.Layout(offScreen, onScreen, 0.25f).Play();
    }

    public async UniTask<string> SelectMenuItem()
    {
        var input = IInputSystem.Resolve();
        while (true)
        {
            await UniTask.NextFrame();
            if (input.GetKeyUp(InputAction.Confirm))
                break;

            var offset = -input.GetAxisUp(InputAxis.Vertical);
            if (offset == 0)
                continue;

            selection = (selection + offset + menuCount) % menuCount;
            buttons[selection].Select();
        }

        return entity.EncounterActions.names[selection];
    }

    public async UniTask TransitionOut()
    {
        await rootPanel.Layout(onScreen, offScreen, 0.25f).Play();
    }
}
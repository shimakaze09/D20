using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System.Linq;
using TMPro;

public interface IActionMenu : IDependency<IActionMenu>
{
    UniTask Setup();
    UniTask TransitionIn();
    UniTask<string> SelectMenuItem();
    UniTask TransitionOut();
}

public class ActionMenu : MonoBehaviour,IActionMenu
{
    [SerializeField] RectTransform rootPanel;
    [SerializeField] List<Button> buttons;
    [SerializeField] Layout onScreen;
    [SerializeField] Layout offScreen;

    private Entity entity;
    private int selection;
    private int menuCount;
    
    public async UniTask Setup()
    {
        selection = 0;
        buttons[0].Select();
        entity = ISoloHeroSystem.Resolve().Hero; // TODO: Get the "current" entity from a "turn" system
        var pairs = buttons.Zip(entity.EncounterActions, (Button button, string action) => (button, action));
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
            if(input.GetKeyUp(InputAction.Confirm))
                break;

            var offset = -input.GetAxisUp(InputAxis.Vertical);
            if(offset==0)
                continue;

            selection = (selection + offset + menuCount) % menuCount;
            buttons[selection].Select();
        }

        return entity.EncounterActions[selection];
    }

    public async UniTask TransitionOut()
    {
        await rootPanel.Layout(onScreen, offScreen, 0.25f).Play();
    }

    private void OnEnable()
    {
        IActionMenu.Register(this);
    }

    private void OnDisable()
    {
        IActionMenu.Reset();
    }
}

